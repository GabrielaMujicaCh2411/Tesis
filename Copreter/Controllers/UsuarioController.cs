using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using AutoMapper;
using Copreter.Domain.Model.DbModel;
using static Copreter.Utils.Keys;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Usuario;
using Copreter.Models.Usuario;
using Copreter.Domain.Model.Model.Usuario;

namespace Copreter.Controllers
{
    public class UsuarioController : BaseController
    {
        #region Fields

        private readonly ILogger<UsuarioController> _logger;

        private readonly IUsuarioService _service;

        private readonly IAccesoService _accesoService;

        #endregion

        public UsuarioController(IMapper mapper, ILogger<UsuarioController> logger,
            IUsuarioService service, IAccesoService accesoService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._accesoService = accesoService;
        }

        public async Task<IActionResult> Index(string? dni, string? apellido)
        {
            var resultService = await this._service.ListarAsync(new UsuarioFilter() { Dni = dni, Apellido = apellido });

            var result = new UsuarioIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<UsuarioDto>>(resultService),
                Filtro = new UsuarioFilterDto(),
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(string? dni, string? apellido)
        {
            var resultService = await this._service.ListarAsync(new UsuarioFilter() { Dni = dni, Apellido = apellido });

            var result = new UsuarioIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<UsuarioDto>>(resultService),
                Filtro = new UsuarioFilterDto(),
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] UsuarioDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(this.Mapper.Map<TUsuario>(dto));
                if (result != null)
                {
                    await this._accesoService.AgregarAsync(result.Id, this.Mapper.Map<TAcceso>(dto));

                    return RedirectToAction(ActionKeys.Index, ControllerKeys.Home);
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);

            return View(this.Mapper.Map<UsuarioDto>(result));
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(this.Mapper.Map<UsuarioDto>(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] UsuarioDto dto)
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
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TUsuario>(dto));
                    if (result)
                    {
                        return Redirect("/Home/IndexAdmin");
                    }
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        // GET: Cliente/Delete/5
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

            return PartialView(PartialViewKeys.Delete, result);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("DeletePopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] UsuarioDto dto)
        {
            if (dto == null)
            {
                return NotFound();
            }

            var result = await this._service.ObtenerAsync(dto.Id);
            if (result != null)
            {
                dto.IdUsuarioModificacion = this.UserId();

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