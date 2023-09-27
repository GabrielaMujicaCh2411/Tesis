using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Copreter.Domain.Service.Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Models.Cotizacion;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Utils;
using Copreter.Domain.Model.Model.Trabajador;
using Copreter.Models.TrabajadorxCotizacion;
using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Service.Dto.TrabajadorxCotizacion;

namespace Copreter.Controllers
{
    [Authorize]
    public class ATrabajadorController : BaseController
    {
        #region Fields

        private readonly ILogger<ATrabajadorController> _logger;

        private readonly ITrabajadorxCotizacionService _service;

        private readonly ICotizacionService _cotizacionService;

        private readonly ITrabajadorService _trabajadorService;

        #endregion

        public ATrabajadorController(IMapper mapper, ILogger<ATrabajadorController> logger,
            ITrabajadorxCotizacionService service, ICotizacionService cotizacionService, ITrabajadorService trabajadorService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._cotizacionService = cotizacionService;
            this._trabajadorService = trabajadorService;
        }


        [HttpGet("PreAsignar/{idCotizacion}")]
        public async Task<IActionResult> PreAsignar(int? idCotizacion = 0)
        {
            if (idCotizacion == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var cotizacion = await this._cotizacionService.ObtenerAsync(idCotizacion.Value);
            var resultService = await this._trabajadorService.ListarAsync(new TrabajadorFilter() { IdEstado = (int)ETrabajadorEstado.Disponible });

            var result = new TrabajadorxCotizacionVM
            {
                IdCotizacion = idCotizacion.Value,
                Cotizacion = this.Mapper.Map<CotizacionDto>(cotizacion),
                DtoList = this.Mapper.Map<IEnumerable<ATrabajadorDto>>(resultService)
            };
            return View(result);
        }

        [HttpPost, ActionName("PostAsignar")]
        public async Task<IActionResult> PostAsignar([FromBody()] TrabajadorxCotizacionDto dto)
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

                    var result = await this._service.AgregarAsync(this.Mapper.Map<IEnumerable<TTrabajadorxCotizacion>>(dto.Lista));
                    if (result)
                    {
                        var resultObra = await this._cotizacionService.ActualizarEstadoAsync(dto.IdCotizacion, ECotizacionEstado.trabajadorAsignado, this.UserId());

                        var resultTrabajador = await this._trabajadorService.ActualizarEstadoAsync(this.Mapper.Map<IEnumerable<TTrabajador>>(dist), ETrabajadorEstado.NoDisponible, this.UserId());

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