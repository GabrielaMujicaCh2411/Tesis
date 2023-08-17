using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Controllers
{
    public class TipoUnidadcontroller : BaseController
    {
        #region Fields

        private readonly ITipoUnidadService _service;

        #endregion

        public TipoUnidadcontroller(ITipoUnidadService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._service.ListarAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}