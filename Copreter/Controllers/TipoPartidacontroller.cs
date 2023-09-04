using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;
using AutoMapper;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Models.Partida;
using Copreter.Models.TipoPartida;
using Copreter.Domain.Service.Dto.TipoPartida;
using Copreter.Domain.Service.Dto.Usuario;
using Copreter.Domain.Service.Dto;
using static Copreter.Utils.Keys;

namespace Copreter.Controllers
{
    public class TipoPartidacontroller : BaseController
    {
        #region Fields

        private readonly ILogger<TipoPartidacontroller> _logger;

        private readonly ITipoPartidaService _service;

        #endregion

        public TipoPartidacontroller(IMapper mapper, ILogger<TipoPartidacontroller> logger, ITipoPartidaService service) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new TipoPartidaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<TipoPartidaDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new TipoPartidaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<TipoPartidaDto>>(resultService)
            };
            return PartialView(result);
        }


        // GET: TipoPartida/Create
        public async Task<IActionResult> Crear()
        {
            return View();
        }

        // POST: TipoPartida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TipoPartidaDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(this.Mapper.Map<TTipoPartida>(dto));
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

            var result = this.Mapper.Map<TipoPartidaEditableVM>(resultService);

            return View(result);
        }

        // GET: TipoPartida/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);

            return View(this.Mapper.Map<TipoPartidaEditableVM>(result));
        }

        // POST: TipoPartida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] TipoPartidaDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    dto.IdUsuarioModificacion = this.UserId();

                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TTipoPartida>(dto));
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

        // GET: TipoPartida/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }


        // GET: TipoPartida/Delete/5
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

            return PartialView(PartialViewKeys.Delete, this.Mapper.Map<TipoPartidaDto>(result));
        }

        // POST: TipoPartida/Delete/5
        [HttpPost, ActionName("DeletePopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] TipoPartidaDto dto)
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
    }
}