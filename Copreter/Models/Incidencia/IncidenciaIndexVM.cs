using Copreter.Domain.Service.Dto.Incidencia;
using Copreter.Domain.Service.Dto.Obra;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Incidencia
{
    public class IncidenciaIndexVM
    {
        public IncidenciaIndexVM()
        {
            this.DtoList = new List<IncidenciaDto>();
        }

        public IEnumerable<IncidenciaDto> DtoList { get; set; }
    }
}
