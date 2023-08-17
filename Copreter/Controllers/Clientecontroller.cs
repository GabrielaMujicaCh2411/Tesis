using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;

namespace Copreter.Controllers
{
    public class Clientecontroller : BaseController
    {
        #region Fields

        private readonly IClienteService _service;

        #endregion

        public Clientecontroller(IClienteService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TCliente dto)
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
        public async Task<IActionResult> Editar(int id,  [Bind()] TCliente dto)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}