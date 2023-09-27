using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Model.Unidad;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.CotizacionxUnidad;
using Copreter.Models.CotizacionxUnidad;
using Copreter.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Copreter.Controllers
{
    [Authorize]
    public class AHerramientaController : BaseController
    {
        #region Fields

        private readonly ILogger<AHerramientaController> _logger;

        private readonly ICotizacionxUnidadService _service;

        private readonly ICotizacionService _cotizacionService;

        private readonly IUnidadService _unidadService;

        #endregion

        public AHerramientaController(IMapper mapper, ILogger<AHerramientaController> logger,
            ICotizacionxUnidadService service, ICotizacionService cotizacionService, IUnidadService unidadService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._cotizacionService = cotizacionService;
            this._unidadService = unidadService;
        }

        [HttpGet("PreAsignarH/{idCotizacion}")]
        public async Task<IActionResult> PreAsignarH(int? idCotizacion = 0)
        {
            if (idCotizacion == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var cotizacion = await this._cotizacionService.ObtenerAsync(idCotizacion.Value);
            var resultService = await this._unidadService.ListarAsync(new UnidadFilter() { IdEstado = (int)EUnidadEstado.Disponible });

            var result = new CotizacionxUnidadVM
            {
                IdCotizacion = idCotizacion.Value,
                Cotizacion = this.Mapper.Map<CotizacionDto>(cotizacion),
                DtoList = this.Mapper.Map<IEnumerable<AUnidadDto>>(resultService)
            };
            return View(result);
        }

        [HttpPost, ActionName("PostAsignar")]
        public async Task<IActionResult> PostAsignar([FromBody()] CotizacionxUnidadDto dto)
        {
            try
            {
                if (dto.Lista != null && dto.Lista.Any())
                {
                    var dist = dto.Lista.Distinct().ToList();

                    foreach (var item in dto.Lista)
                    {
                        item.IdUsuarioRegistro = this.UserId();
                    }

                    var result = await this._service.AgregarAsync(this.Mapper.Map<IEnumerable<TCotizacionxUnidad>>(dto.Lista));
                    if (result)
                    {
                        var resultObra = await this._cotizacionService.ActualizarEstadoAsync(dto.IdCotizacion, ECotizacionEstado.herramientaAsignada, this.UserId());

                        var resultTrabajador = await this._unidadService.ActualizarEstadoAsync(this.Mapper.Map<IEnumerable<TUnidad>>(dist), EUnidadEstado.NoDisponible, this.UserId());

                        return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra);
                    }
                }

                return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }
    }
}