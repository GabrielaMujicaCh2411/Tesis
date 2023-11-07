using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.OrdenServicio;
using Copreter.Models.Obra;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class OrdenServicioController : BaseController
    {
        #region Fields

        private readonly ILogger<OrdenServicioController> _logger;

        private readonly IOrdenServicioService _service;

        private readonly IObraService _obraservice;

        private readonly ICotizacionService _cotizacionService;

        private readonly IPagoService _pagoService;

        #endregion

        public OrdenServicioController(IMapper mapper, ILogger<OrdenServicioController> logger, IWebHostEnvironment hosting,
            IOrdenServicioService service, IObraService obraservice, ICotizacionService cotizacionService, IPagoService pagoService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._hosting = hosting;

            this._obraservice = obraservice;
            this._cotizacionService = cotizacionService;
            this._pagoService = pagoService;
        }


        public async Task<IActionResult> Cargar(int idObra)
        {
            var cotizacion = await this._cotizacionService.ObtenerPorIdObraAsync(idObra);

            var result = new OrdenServicioDto
            {
                IdCotizacion = cotizacion.Id,
                IdObra = idObra,
            };
            return View(result);
        }

        public async Task<IActionResult> Enviar([Bind()] OrdenServicioDto dto)
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

                var result = await this._service.AgregarAsync(this.Mapper.Map<TOrdenServicio>(dto));
                if (result)
                {
                    await this._cotizacionService.ActualizarEstadoAsync(dto.IdCotizacion, (int)ECotizacionEstado.OrdenServicioEnviado, this.UserId());

                    await this._obraservice.ActualizarEstadoAsync(dto.IdObra, (int)EObraEstado.OrdenEnviado, this.UserId());

                    return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra);
                }
                return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Detalle(int idObra)
        {
            if (idObra == null) return RedirectToAction(nameof(Index));

            var cotizacion = await this._cotizacionService.ObtenerPorIdObraAsync(idObra);

            var resultService = await this._service.ObtenerPorIdCotizacionAsync(cotizacion.Id);

            var result = this.Mapper.Map<OrdenServicioDto>(resultService);
            result.IdObra = idObra;
            return View(result);
        }
    }
}
