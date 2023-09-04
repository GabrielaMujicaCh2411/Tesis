using Copreter.Domain.Service.Dto.Partida;
using Copreter.Domain.Service.Dto.TipoPartida;

namespace Copreter.Models.TipoPartida
{
    public class TipoPartidaIndexVM
    {
        public TipoPartidaIndexVM()
        {
            this.DtoList = new List<TipoPartidaDto>();
        }

        public IEnumerable<TipoPartidaDto> DtoList { get; set; }
    }
}
