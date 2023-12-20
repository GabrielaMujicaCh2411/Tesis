using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cotizacion;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Models.Cotizacion;
using Copreter.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Copreter.Controllers
{
    [Authorize]
    public class CotizarController : BaseController
    {
        #region Fields

        private readonly ILogger<CotizarController> _logger;

        private readonly ICotizacionService _service;

        private readonly IEstadoCotizacionService _estadoCotizacionService;

        private readonly IPartidaService _partidaService;

        private readonly IObraPartidaService _obraPartidaService;

        private readonly IObraService _obraService;

        private readonly IConfiguracionService _configuracionService;

        #endregion

        public CotizarController(IMapper mapper, ILogger<CotizarController> logger,
            ICotizacionService service, IEstadoCotizacionService estadoCotizacionService, IPartidaService partidaService,
            IObraPartidaService obraPartidaService, IObraService obraService, IConfiguracionService configuracionService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._estadoCotizacionService = estadoCotizacionService;
            this._partidaService = partidaService;
            this._obraPartidaService = obraPartidaService;
            this._obraService = obraService;
            this._configuracionService = configuracionService;
        }

        public async Task<IActionResult> Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CotizacionFilter() { IdEstado = idEstado });

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoCotizacionService.ListarAsync());

            var result = new CotizacionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CotizacionDto>>(resultService),
                Filtro = new CotizacionFilterDto(),
                EstadoLista = estadoLista.GetItems(),
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CotizacionFilter() { IdEstado = idEstado });
            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoCotizacionService.ListarAsync());


            var result = new CotizacionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CotizacionDto>>(resultService),
                Filtro = new CotizacionFilterDto(),
                EstadoLista = estadoLista.GetItems(),
            };
            return PartialView(result);
        }

        [HttpGet("PreCotizar/{idObra}")]
        public async Task<IActionResult> PreCotizar(int? idObra = 0)
        {
            if (idObra == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var igv = await this._configuracionService.ObtenerValorDecimal("IGV");
            var obra = await this._obraService.ObtenerAsync(idObra.Value);
            var resultService = await this._partidaService.ListarAsync();
            var result = new CotizarVM
            {
                Igv = igv,
                Obra = this.Mapper.Map<ObraDto>(obra),
                DtoList = this.Mapper.Map<IEnumerable<PartidaDto>>(resultService)
            };
            return View(result);
        }

        [HttpPost, ActionName("PostCotizar")]
        public async Task<IActionResult> PostCotizar([FromBody()] CotizarDto dto)
        {
            try
            {
                var resultPartida = await this._obraPartidaService.AgregarAsync(this.Mapper.Map<IEnumerable<TObraxPartida>>(dto.Lista));

                var igv = await this._configuracionService.ObtenerValorDecimal("IGV");
                var gananciaEmpresa = await this._configuracionService.ObtenerValorDecimal("GANANCIA");

                var cotizacion = this.Mapper.Map<TCotizacion>(dto);

                var gananciaEmpresaCal = dto.SubTotal / gananciaEmpresa;
                var igvCal = igv / 100;

                var costoSubTotal = cotizacion.SubTotal;

                decimal costoIgv = 0;
                decimal costoTotal = 0;

                if (dto.IsIgv)
                {
                    costoSubTotal = gananciaEmpresaCal;
                    costoIgv = gananciaEmpresaCal * igvCal;
                    costoTotal = gananciaEmpresaCal + costoIgv;
                }
                else
                {
                    costoIgv = dto.SubTotal * igvCal;
                    costoTotal = gananciaEmpresaCal + costoIgv;
                }

                cotizacion.IsIgv = dto.IsIgv;
                cotizacion.SubTotal = costoSubTotal;
                cotizacion.Total = costoTotal;
                cotizacion.IgvCalculado = costoIgv;
                cotizacion.Igv = igvCal;
                cotizacion.IdEstadoCotizacion = 1;
                var result = await this._service.AgregarAsync(cotizacion);
                if (result)
                {
                    var resultObra = await this._obraService.ActualizarEstadoAsync(dto.IdObra, (int)Domain.Model.Enums.EObraEstado.Cotizado, this.UserId());
                    return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> CotizacionPdf(int id)
        {
            try
            {
                var resultService = await this._service.ObtenerAsync(id);
                if (resultService != null)
                {
                    var resultPartidaXObra = await this._obraPartidaService.ListarPorIdObraAsync(resultService.IdObra);

                    var result = this.Mapper.Map<CotizacionEditableVM>(resultService);
                    result.ObraPartidaLista = this.Mapper.Map<IEnumerable<ObraPartidaDto>>(resultPartidaXObra);

                    return new ViewAsPdf("CotizacionPdf", result)
                    {
                        FileName = $"Cotizacion-{id}.pdf",
                        PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                        PageSize = Rotativa.AspNetCore.Options.Size.A4
                    };
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> CotizacionPorObraPdf(int idObra)
        {
            try
            {
                var resultService = await this._service.ObtenerPorIdObraAsync(idObra);
                if (resultService != null)
                {
                    var resultPartidaXObra = await this._obraPartidaService.ListarPorIdObraAsync(resultService.IdObra);

                    var result = this.Mapper.Map<CotizacionEditableVM>(resultService);
                    result.ObraPartidaLista = this.Mapper.Map<IEnumerable<ObraPartidaDto>>(resultPartidaXObra);

                    return new ViewAsPdf("CotizacionPdf", result)
                    {
                        FileName = $"Cotizacion-{resultService.Id}.pdf",
                        PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                        PageSize = Rotativa.AspNetCore.Options.Size.A4
                    };
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }
    }
}