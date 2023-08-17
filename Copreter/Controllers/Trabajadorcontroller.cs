using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class Trabajadorcontroller : BaseController
    {
        #region Fields

        private readonly ITrabajadorService _service;

        private readonly IEstadoTrabajadorService _estadoTrabajadorService;

        private readonly ITipoTrabajadorService _tipoTrabajadorService;

        #endregion

        public Trabajadorcontroller(ITrabajadorService service, IEstadoTrabajadorService estadoTrabajadorService, ITipoTrabajadorService tipoTrabajadorService)
        {
            this._service = service;
            this._estadoTrabajadorService = estadoTrabajadorService;
            this._tipoTrabajadorService = tipoTrabajadorService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._service.ListarAsync();
            return View(result);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.ListaTipoTrabajador = await this._tipoTrabajadorService.ListarAsync();
            ViewBag.ListaEstadoTrabajador = await this._estadoTrabajadorService.ListarAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TTrabajador dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(dto);
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

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] TTrabajador dto)
        {
            try
            {
                //if (id != dto)
                //{
                //    return NotFound();
                //}

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
            catch
            {
                return View(dto);
            }
        }

    }
}