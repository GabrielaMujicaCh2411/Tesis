using Copreter.Domain.Service.Dto.Partida;
using Copreter.Domain.Service.Dto.TipoPartida;

namespace Copreter.Models.TipoPartida
{
    public class TipoPartidaIndexVM
    {
        public TipoPartidaIndexVM()
        {
            this.DtoList = new List<TipoPartidaDto>();

            this.Filtro = new TipoPartidaFiltroDto();
        }

        public IEnumerable<TipoPartidaDto> DtoList { get; set; }

        public TipoPartidaFiltroDto Filtro { get; set; }
    }
}
