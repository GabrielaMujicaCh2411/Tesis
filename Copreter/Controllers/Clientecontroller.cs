using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Cliente;
using AutoMapper;
using Copreter.Domain.Model.DbModel;
using static Copreter.Utils.Keys;
using Copreter.Models.Cliente;
using Copreter.Domain.Service.Dto;

namespace Copreter.Controllers
{
    public class ClienteController : BaseController
    {
        #region Fields

        private readonly ILogger<ClienteController> _logger;

        private readonly IClienteService _service;

        private readonly IUsuarioService _usuarioService;

        #endregion

        public ClienteController(IMapper mapper, ILogger<ClienteController> logger,
            IClienteService service, IUsuarioService usuarioService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new ClienteIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ClienteDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new ClienteIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ClienteDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] ClienteDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(this.Mapper.Map<TCliente>(dto));
                if (result)
                {
                    await this._usuarioService.AgregarAsync(this.Mapper.Map<TUsuario>(dto));

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

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] ClienteDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TCliente>(dto));
                    if (result)
                    {
                        return Redirect("/Home/VistaAdministrador");
                    }
                }
                return View(dto);
            }
            catch
            {
                return View(dto);
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
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] ClienteDto dto)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}