using AutoMapper;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Model.Obra;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Domain.Service.Dto;
using Copreter.Models.Obra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Copreter.Domain.Model.Model.Incidencia;
using Copreter.Domain.Service.Dto.Incidencia;
using Copreter.Models.Incidencia;

namespace Copreter.Controllers
{
    [Authorize]
    public class IncidenciaController : BaseController
    {
        #region Fields

        private readonly ILogger<IncidenciaController> _logger;

        private readonly IIncidenciaService _service;

        #endregion

        public IncidenciaController(IMapper mapper, ILogger<IncidenciaController> logger, IIncidenciaService service) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
        }

        public async Task<IActionResult> Index(int? idPedido = 0)
        {

            var resultService = await this._service.ListarAsync(new IncidenciaFilter() { IdPedido =idPedido});

            var result = new IncidenciaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<IncidenciaDto>>(resultService),
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? idPedido = 0)
        {
            var resultService = await this._service.ListarAsync(new IncidenciaFilter() { IdPedido = idPedido });

            var result = new IncidenciaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<IncidenciaDto>>(resultService)
            };
            return PartialView(result);
        }
    }
}
