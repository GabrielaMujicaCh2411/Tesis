using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;

namespace Copreter.Controllers
{
    public class Partidascontroller : BaseController
    {
        #region Fields

        private readonly IPartidaService _service;

        #endregion

        public Partidascontroller(IPartidaService service)
        {
            this._service = service;
        }


        public async Task<IActionResult> Index()
        {
            var result = await this._service.ListarAsync();
            return View(result);
        }

        // GET: Partida/Create
        public async Task<IActionResult> Crear()
        {
            return View();
        }

        // POST: Partida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TPartida dto)
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

        // GET: Partida/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }

        // POST: Partida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] TPartida dto)
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

        // GET: Partida/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }
    }
}