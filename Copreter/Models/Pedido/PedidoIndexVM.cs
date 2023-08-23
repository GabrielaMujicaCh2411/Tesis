using Copreter.Domain.Service.Dto.Pedido;

namespace Copreter.Models.Pedido
{
    public class PedidoIndexVM
    {
        public PedidoIndexVM()
        {
            this.DtoList = new List<PedidoDto>();
        }

        public IEnumerable<PedidoDto> DtoList { get; set; }
    }
}
