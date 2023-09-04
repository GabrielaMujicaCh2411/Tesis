using Copreter.Domain.Service.Dto.Obra;
using Copreter.Domain.Service.Dto.Partida;

namespace Copreter.Models.Partida
{
    public class PartidaIndexVM
    {
        public PartidaIndexVM()
        {
            this.DtoList = new List<PartidaDto>();
        }

        public IEnumerable<PartidaDto> DtoList { get; set; }
    }
}
