using Copreter.Domain.Service.Dto.Obra;
using Copreter.Domain.Service.Dto.Pedido;

namespace Copreter.Models.Obra
{
    public class ObraIndexVM
    {
        public ObraIndexVM()
        {
            this.DtoList = new List<ObraDto>();
        }

        public IEnumerable<ObraDto> DtoList { get; set; }
    }
}
