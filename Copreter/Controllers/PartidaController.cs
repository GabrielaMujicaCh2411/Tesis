using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;
using AutoMapper;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Models.Partida;
using Copreter.Domain.Service.Dto;
using Copreter.Utils;
using Copreter.Models.Obra;
using Copreter.Domain.Service.Dto.Usuario;
using static Copreter.Utils.Keys;

namespace Copreter.Controllers
{
    public class PartidaController : BaseController
    {
        #region Fields

        private readonly ILogger<PartidaController> _logger;

        private readonly IPartidaService _service;

        private readonly ITipoPartidaService _tipoPartidaService;

        #endregion

        public PartidaController(IMapper mapper, ILogger<PartidaController> logger, IPartidaService service, ITipoPartidaService tipoPartidaService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._tipoPartidaService = tipoPartidaService;
        }


        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new PartidaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PartidaDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new PartidaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PartidaDto>>(resultService)
            };
            return PartialView(result);
        }

        // GET: Partida/Create
        public async Task<IActionResult> Crear()
        {
            return View();
        }

        // POST: Partida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] PartidaDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(this.Mapper.Map<TPartida>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(dto);
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id.Value);

            var tipoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._tipoPartidaService.ListarAsync());

            var result = this.Mapper.Map<PartidaEditableVM>(resultService);
            result.TipoLista = tipoLista.GetItems();

            return View(result);
        }

        // GET: Partida/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id.Value);
            var tipoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._tipoPartidaService.ListarAsync());

            var result = this.Mapper.Map<PartidaEditableVM>(resultService);
            result.TipoLista = tipoLista.GetItems();
            return View(result);
        }

        // POST: Partida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] PartidaDto dto)
        {
            try
            {
                if (id != dto.IdTipoPartida)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    dto.IdUsuarioModificacion = this.UserId();

                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TPartida>(dto));
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(dto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Partida/Delete/5
        [HttpPost, ActionName("DeletePopup")]
        public async Task<IActionResult> DeletePopup([FromBody] EditDto dto)
        {
            if (dto == null || dto.Id == 0)
            {
                return NotFound();
            }

            var result = await this._service.ObtenerAsync(dto.Id);
            if (result == null)
            {
                return NotFound();
            }

            return PartialView(PartialViewKeys.Delete, this.Mapper.Map<PartidaDto>(result));
        }

        // POST: Partida/Delete/5
        [HttpPost, ActionName("DeletePopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] PartidaDto dto)
        {
            if (dto == null)
            {
                return NotFound();
            }

            var result = await this._service.ObtenerAsync(dto.Id);
            if (result != null)
            {
                result.IdUsuarioModificacion = 1;

                await this._service.EliminarAsync(dto.Id, this.UserId());
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}