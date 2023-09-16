using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Factura;
using Copreter.Domain.Model.DbModel;
using Copreter.Utils;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Service.Dto;
using Copreter.Models.Trabajador;

namespace Copreter.Controllers
{
    public class Facturacontroller : BaseController
    {
        #region Fields

        private readonly ILogger<Facturacontroller> _logger;

        private readonly IFacturaService _service;

        private readonly IObraService _obraservice;

        private readonly ICotizacionService _cotizacionService;

        #endregion

        public Facturacontroller(IMapper mapper, ILogger<Facturacontroller> logger, IWebHostEnvironment hosting,
            IFacturaService service, IObraService obraservice, ICotizacionService cotizacionService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._hosting = hosting;

            this._obraservice = obraservice;
            this._cotizacionService = cotizacionService;
        }

        public async Task<IActionResult> Detalle(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id);

            if (resultService == null) return RedirectToAction(nameof(Index));

            var resultCotizacionService = await this._cotizacionService.ObtenerAsync(resultService.IdCotizacion);

            var result = new FacturaDetalleDto();
            result.Id = id;
            result.Fecha = resultCotizacionService.Fecha;
            result.Pago = resultCotizacionService.Total / 2;
            result.Pago2 = resultCotizacionService.Total - result.Pago;
            result.IdEstadoCotizacion = resultCotizacionService.IdEstadoCotizacion;

            return View(result);
        }

        public IActionResult Cargar(int idCotizacion)
        {
            var result = new FacturaDto
            {
                IdCotizacion = idCotizacion
            };
            return View(result);
        }


        public async Task<IActionResult> Enviar([Bind()] FacturaDto dto)
        {
            try
            {
                if (dto.Foto != null)
                {
                    string ficherosImagenes = Path.Combine(this._hosting.WebRootPath, "images");
                    var guidImage = Guid.NewGuid().ToString() + dto.Foto.FileName;
                    string rutaDefinitiva = Path.Combine(ficherosImagenes, guidImage);
                    dto.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
                    dto.Imagen = guidImage;
                }

                dto.IdUsuarioRegistro = this.UserId();

                var result = await this._service.AgregarAsync(this.Mapper.Map<TFactura>(dto));
                if (result)
                {
                    var cotización = await this._cotizacionService.ObtenerAsync(dto.IdCotizacion);

                    await this._cotizacionService.ActualizarEstado(cotización.IdObra, ECotizacionEstado.Primerfacturado, this.UserId());

                    await this._obraservice.ActualizarEstado(cotización.IdObra, EObraEstado.Facturado, this.UserId());

                    return RedirectToAction(nameof(Index), Keys.ControllerKeys.Cotizacion);
                }
                return RedirectToAction(nameof(Index), Keys.ControllerKeys.Cotizacion);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }
    }
}