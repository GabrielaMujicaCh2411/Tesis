using AutoMapper;
using Copreter.Domain.Model.Model.Cotizacion;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Models.Cotizacion;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class Cotizacioncontroller : BaseController
    {
        #region Fields
        
        private readonly ILogger<Cotizacioncontroller> _logger;

        private readonly ICotizacionService _service;

        private readonly IEstadoCotizacionService _estadoCotizacionService;

        #endregion

        public Cotizacioncontroller(IMapper mapper, ILogger<Cotizacioncontroller> logger, 
            ICotizacionService service, IEstadoCotizacionService estadoCotizacionService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._estadoCotizacionService = estadoCotizacionService;
        }

        public async Task<IActionResult> Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CotizacionFilter() { IdEstado = idEstado});

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoCotizacionService.ListarAsync());

            var result = new CotizacionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CotizacionDto>>(resultService),
                Filtro = new CotizacionFilterDto(),
                EstadoLista = estadoLista.GetItems(),
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CotizacionFilter() { IdEstado = idEstado });
            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoCotizacionService.ListarAsync());


            var result = new CotizacionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CotizacionDto>>(resultService),
                Filtro = new CotizacionFilterDto(),
                EstadoLista = estadoLista.GetItems(),
            };
            return PartialView(result);
        }

    }
}