namespace Copreter.Domain.Service.Dto.Pedido
{
    public class PedidoSinDevolverDto : PedidoDto
    {
        public PedidoSinDevolverDto()
        {
            this.DiasSinDevolver = DateTime.Now.Day - (FechaEntrega.Value.Day + CantidadDias.Value);    
        }

        public int DiasSinDevolver { get; set; }
    }
}
