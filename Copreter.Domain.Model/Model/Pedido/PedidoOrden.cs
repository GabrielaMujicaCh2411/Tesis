using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Model.Model.Pedido
{
    public class PedidoOrden : TPedido
    {
        public int IdPedido { get; set; }
        public int CantidadDias { get; set; }
        public decimal PrecioPedido { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
