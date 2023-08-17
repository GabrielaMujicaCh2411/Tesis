using Copreter.Domain.Service.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class PedidoController : BaseController
    {
        #region Fields

        private readonly IPedidoService _service;

        #endregion

        public PedidoController(IPedidoService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._service.ListarAsync();
            return View(result);
        }
    }
}