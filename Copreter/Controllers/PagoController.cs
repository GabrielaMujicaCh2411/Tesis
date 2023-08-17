using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Copreter.Controllers
{
    public class PagoController : Controller
    {
        #region Fields

        private readonly IPagoService _service;

        #endregion


        public PagoController(IPagoService service)
        {
            this._service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: Pago/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TPago dto)
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
                    return Redirect("/Home/VistaAdministrador");
                }
                return View(dto);
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}