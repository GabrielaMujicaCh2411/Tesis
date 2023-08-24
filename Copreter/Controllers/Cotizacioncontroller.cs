using AutoMapper;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Models.Cotizacion;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class Cotizacioncontroller : BaseController
    {
        #region Fields

        private readonly ICotizacionService _service;
        #endregion

        public Cotizacioncontroller(IMapper mapper, ICotizacionService service) : base(mapper)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new CotizacionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CotizacionDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new CotizacionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CotizacionDto>>(resultService)
            };
            return PartialView(result);
        }

    }
}