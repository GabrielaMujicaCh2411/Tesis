using Copreter.Domain.Service.Dto.Pedido;

namespace Copreter.Models.Pedido
{
    public class PedidoSinDevolverVM
    {
        public PedidoSinDevolverVM()
        {
            this.DtoList = new List<PedidoSinDevolverDto>();
        }

        public IEnumerable<PedidoSinDevolverDto> DtoList { get; set; }
    }
}
