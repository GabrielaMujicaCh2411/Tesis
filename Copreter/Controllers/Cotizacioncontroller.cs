using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cotizacion;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Models.Cotizacion;
using Copreter.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Copreter.Controllers
{
    [Authorize]
    public class Cotizacioncontroller : BaseController
    {
        #region Fields

        private readonly ILogger<Cotizacioncontroller> _logger;

        private readonly ICotizacionService _service;

        private readonly IEstadoCotizacionService _estadoCotizacionService;

        private readonly IPartidaService _partidaService;

        private readonly IObraPartidaService _obraPartidaService;

        private readonly IObraService _obraService;

        #endregion

        public Cotizacioncontroller(IMapper mapper, ILogger<Cotizacioncontroller> logger,
            ICotizacionService service, IEstadoCotizacionService estadoCotizacionService, IPartidaService partidaService, IObraPartidaService obraPartidaService, IObraService obraService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._estadoCotizacionService = estadoCotizacionService;
            this._partidaService = partidaService;
            this._obraPartidaService = obraPartidaService;
            this._obraService = obraService;
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

        public async Task<IActionResult> Cotizar(int? idObra = 0)
        {
            if(idObra == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var obra = await this._obraService.ObtenerAsync(idObra.Value);
            var resultService = await this._partidaService.ListarAsync();

            var result = new CotizarVM
            {
                Obra = this.Mapper.Map<ObraDto>(obra),
                DtoList = this.Mapper.Map<IEnumerable<PartidaDto>>(resultService)
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cotizar([Bind()] CotizarDto dto)
        {
            try
            {
                var resultPartida = await this._obraPartidaService.AgregarAsync(this.Mapper.Map<IEnumerable<TObraxPartida>>(dto.Lista));

                var result = await this._service.AgregarAsync(this.Mapper.Map<TCotizacion>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
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
                if(resultService != null)
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

    }
}