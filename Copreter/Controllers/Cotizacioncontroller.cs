using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cotizacion;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Models.Cotizacion;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Copreter.Controllers
{
    public class Cotizacioncontroller : BaseController
    {
        #region Fields

        private readonly ILogger<Cotizacioncontroller> _logger;

        private readonly ICotizacionService _service;

        private readonly IEstadoCotizacionService _estadoCotizacionService;

        private readonly IPartidaService _partidaService;

        private readonly IObraPartidaService _obraPartidaService;

        #endregion

        public Cotizacioncontroller(IMapper mapper, ILogger<Cotizacioncontroller> logger,
            ICotizacionService service, IEstadoCotizacionService estadoCotizacionService, IPartidaService partidaService, IObraPartidaService obraPartidaService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._estadoCotizacionService = estadoCotizacionService;
            this._partidaService = partidaService;
            this._obraPartidaService = obraPartidaService;
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
            var resultService = await this._partidaService.ListarAsync();

            var result = new CotizarVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PartidaDto>>(resultService)
            };
            return PartialView(result);
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
                var result = await this._service.ObtenerAsync(id);

                return new ViewAsPdf("ListarPdf", this.Mapper.Map<CotizacionEditableVM>(result))
                {
                    FileName = $"Cotizacion-{id}",
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.A4
                };
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        
        }

    }
}