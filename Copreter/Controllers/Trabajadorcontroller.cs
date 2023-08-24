using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Models.Trabajador;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;
using static Copreter.Utils.Keys;

namespace Copreter.Controllers
{
    public class Trabajadorcontroller : BaseController
    {
        #region Fields

        private readonly ITrabajadorService _service;

        private readonly IEstadoTrabajadorService _estadoTrabajadorService;

        private readonly ITipoTrabajadorService _tipoTrabajadorService;

        #endregion

        public Trabajadorcontroller(IMapper mapper, ITrabajadorService service, IEstadoTrabajadorService estadoTrabajadorService, ITipoTrabajadorService tipoTrabajadorService) : base(mapper)
        {
            this._service = service;
            this._estadoTrabajadorService = estadoTrabajadorService;
            this._tipoTrabajadorService = tipoTrabajadorService;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new TrabajadorIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<TrabajadorDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new TrabajadorIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<TrabajadorDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear()
        {
            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoTrabajadorService.ListarAsync());
            var tipoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._tipoTrabajadorService.ListarAsync());

            var result = new TrabajadorEditableVM
            {
                EstadoLista = estadoLista.GetItems(),
                TipoLista = tipoLista.GetItems()
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TrabajadorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(this.Mapper.Map<TTrabajador>(dto));
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

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoTrabajadorService.ListarAsync());
            var tipoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._tipoTrabajadorService.ListarAsync());

            var resultService = await this._service.ObtenerAsync(id);

            var result = this.Mapper.Map<TrabajadorEditableVM>(resultService);
            result.EstadoLista = estadoLista.GetItems();
            result.TipoLista = tipoLista.GetItems();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] TrabajadorDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TTrabajador>(dto));
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(dto);
            }
            catch
            {
                return View(dto);
            }
        }

        // GET: Trabajador/Delete/5
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

            return PartialView(PartialViewKeys.Delete, this.Mapper.Map<TrabajadorDto>(result));
        }

        // POST: Trabajador/Delete/5
        [HttpPost, ActionName("DeletePopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] TrabajadorDto dto)
        {
            if (dto == null)
            {
                return NotFound();
            }

            var result = await this._service.ObtenerAsync(dto.Id);
            if (result != null)
            {
                result.IdUsuarioModificacion = 1;

                await this._service.EliminarAsync(dto.Id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}