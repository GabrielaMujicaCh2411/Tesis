using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;

namespace Copreter.Controllers
{
    public class TipoPartidacontroller : BaseController
    {
        #region Fields

        private readonly ITipoPartidaService _service;

        #endregion

        public TipoPartidacontroller(ITipoPartidaService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._service.ListarAsync(); 
            return View(result);

        }

        // GET: TipoPartida/Create
        public async Task<IActionResult> Crear()
        {
            return View();
        }

        // POST: TipoPartida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TTipoPartida dto)
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

        // GET: TipoPartida/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }

        // POST: TipoPartida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] TTipoPartida dto)
        {
            try
            {
                if (id != dto.IdTipoPartida)
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

        // POST: TipoPartida/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var result = await this._service.EliminarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}