using Copreter.Domain.Service.Dto.Cita;
using Copreter.Domain.Service.Dto.Obra;

namespace Copreter.Models.Cita
{
    public class CitaIndexVM
    {
        public CitaIndexVM()
        {
            this.DtoList = new List<CitaDto>();
        }

        public IEnumerable<CitaDto> DtoList { get; set; }
    }
}
