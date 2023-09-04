using AutoMapper;
using Copreter.Domain.Model.Model.Cita;
using Copreter.Domain.Model.Model.Obra;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Models.Obra;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class CitaController : BaseController
    {

        #region Fields

        private readonly ILogger<CitaController> _logger;

        private readonly ICitaService _service;

        #endregion


        public CitaController(IMapper mapper, ILogger<CitaController> logger,
            ICitaService service) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
        }

        public async Task<IActionResult> Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CitaFilter() { IdEstado = idEstado });

            var result = new ObraIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CitaFilter() { IdEstado = idEstado });

            var result = new ObraIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraDto>>(resultService)
            };
            return PartialView(result);
        }

    }
}