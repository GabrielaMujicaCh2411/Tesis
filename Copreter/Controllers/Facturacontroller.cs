using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Factura;
using Copreter.Domain.Model.DbModel;
using Copreter.Utils;
using Copreter.Domain.Model.Enums;

namespace Copreter.Controllers
{
    public class Facturacontroller : BaseController
    {
        #region Fields

        private readonly ILogger<Facturacontroller> _logger;

        private readonly IFacturaService _service;

        private readonly IObraService _obraservice;

        private readonly ICotizacionService _cotizacionService;

        private readonly IPagoService _pagoService;

        #endregion

        public Facturacontroller(IMapper mapper, ILogger<Facturacontroller> logger, IWebHostEnvironment hosting,
            IFacturaService service, IObraService obraservice, ICotizacionService cotizacionService, IPagoService pagoService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._hosting = hosting;

            this._obraservice = obraservice;
            this._cotizacionService = cotizacionService;
            this._pagoService = pagoService;
        }

        public async Task<IActionResult> Detalle(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerPorIdCotizacionAsync(id);

            if (resultService == null) return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra, new { userId = this.UserId() });

            var resultCotizacionService = await this._cotizacionService.ObtenerAsync(resultService.IdCotizacion);

            var result = new FacturaDetalleDto
            {
                Id = resultService.Id,
                IdCotizacion = resultService.IdCotizacion,
                Fecha = resultCotizacionService.Fecha,
                IdEstadoCotizacion = resultCotizacionService.IdEstadoCotizacion,
                Imagen = resultService.Imagen,
                Total = resultCotizacionService.Total
            };

            var factura = await this._pagoService.ObtenerPoIdCotizacionAsync(resultService.IdCotizacion);
            if (factura != null)
            {
              
                result.Monto = factura.Saldo;
                result.Saldo = 0;
            }
            else
            {
                result.Monto = resultCotizacionService.Total / 2;
                result.Saldo = resultCotizacionService.Total - result.Monto;
            }

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

                    await this._cotizacionService.ActualizarEstadoPorObraAsync(cotización.IdObra, (int)ECotizacionEstado.Primerfacturado, this.UserId());

                    await this._obraservice.ActualizarEstadoAsync(cotización.IdObra, (int)EObraEstado.Facturado, this.UserId());

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