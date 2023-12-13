using Copreter.Domain.Service.Dto.ObraIncidencia;

namespace Copreter.Models.ObraIncidencia
{
    public class ObraIncidenciaIndexVM
    {
        public ObraIncidenciaIndexVM()
        {
            this.DtoList = new List<ObraIncidenciaDto>();
        }

        public IEnumerable<ObraIncidenciaDto> DtoList { get; set; }
    }
}
