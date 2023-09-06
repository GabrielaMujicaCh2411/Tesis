using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using static Copreter.Utils.Keys;
using Copreter.Domain.Service.Dto.Unidad;
using Copreter.Models.Unidad;
using Copreter.Utils;
using System.Security.Claims;

namespace Copreter.Controllers
{
    public class Unidadcontroller : BaseController
    {
        #region Fields

        private readonly IUnidadService _service;
        private readonly IEstadoUnidadService _estadoUnidadservice;
        private readonly ITipoUnidadService _tipoUnidadservice;

        #endregion

        public Unidadcontroller(IMapper mapper, IUnidadService service, IEstadoUnidadService estadoUnidadservice, ITipoUnidadService tipoUnidadservice) : base(mapper)
        {
            this._service = service;
            this._estadoUnidadservice = estadoUnidadservice;
            this._tipoUnidadservice = tipoUnidadservice;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new UnidadIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<UnidadDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new UnidadIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<UnidadDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear()
        {
            var estadoUnidadLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoUnidadservice.ListarAsync());
            var tipoUnidadLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._tipoUnidadservice.ListarAsync());

            var result = new UnidadEditableVM
            {
                EstadoLista = estadoUnidadLista.GetItems(),
                TipoLista = tipoUnidadLista.GetItems()
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] UnidadDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            if (dto.Foto != null)
            {
                string ficherosImagenes = Path.Combine("C:\\Temp\\Copreter", "images");
                var guidImage = Guid.NewGuid().ToString() + dto.Foto.FileName;
                string rutaDefinitiva = Path.Combine(ficherosImagenes, guidImage);
                dto.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
                dto.Imagen = guidImage;
            }

            dto.IdUsuarioRegistro = this.UserId();

            var result = await this._service.AgregarAsync(this.Mapper.Map<TUnidad>(dto));
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var estadoUnidadLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoUnidadservice.ListarAsync());
            var tipoUnidadLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._tipoUnidadservice.ListarAsync());

            var resultService = await this._service.ObtenerAsync(id);

            var result = this.Mapper.Map<UnidadEditableVM>(resultService);
            result.EstadoLista = estadoUnidadLista.GetItems();
            result.TipoLista = tipoUnidadLista.GetItems();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] UnidadDto dto)
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

                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TUnidad>(dto));
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

        // GET: Unidad/Delete/5
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

            return PartialView(PartialViewKeys.Delete, this.Mapper.Map<UnidadDto>(result));
        }

        // POST: Unidad/Delete/5
        [HttpPost, ActionName("DeletePopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] UnidadDto dto)
        {
            if (dto == null)
            {
                return NotFound();
            }

            var result = await this._service.ObtenerAsync(dto.Id);
            if (result != null)
            {
                dto.IdUsuarioModificacion = this.UserId();

                await this._service.EliminarAsync(dto.Id);
            }

            return RedirectToAction(nameof(Index));
        }


        #region Catalago


        public async Task<IActionResult> IndexCatalago(int type)
        {
            var resultService = await this._service.ListarCatalagoAsync(type);

            var result = new UnidadIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<UnidadDto>>(resultService)
            };
            return View(Keys.ActionKeys.IndexCatalago, result);
        }

        public async Task<IActionResult> DetalleCatalago(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);

            return View(Keys.ActionKeys.DetalleCatalago, result);
        }

        #endregion
    }
}