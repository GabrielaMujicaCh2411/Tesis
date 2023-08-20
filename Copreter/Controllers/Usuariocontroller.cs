using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;
using AutoMapper;

namespace Copreter.Controllers
{
    public class Usuariocontroller : BaseController
    {
        #region Fields

        private readonly IUsuarioService _service;

        private readonly IRolService _rolService;

        #endregion

        public Usuariocontroller(IMapper mapper, IUsuarioService service, IRolService rolService) : base(mapper)
        {
            this._service = service;
            this._rolService = rolService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._service.ListarAsync();
            return View(result);
        }

        public async Task<IActionResult> Asignar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.listarRol = await this._rolService.ListarAsync();

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TUsuario dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var usuarioExiste = await this._service.ObtenerAsync(dto.Id);
            if (usuarioExiste == null)
            {
                var result = await this._service.AgregarAsync(dto);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dto);
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id);
            return View(result);
        }

        [HttpPost, ActionName("EditPopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] TUsuario dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await this._service.ActualizarAsync(id, dto);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}