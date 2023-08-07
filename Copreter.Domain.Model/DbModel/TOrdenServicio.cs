using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TOrdenServicio
    {
        public string IdOrden { get; set; } = null!;
        public DateTime? FechaOrden { get; set; }
        public decimal? Liquidacion { get; set; }
        public string? IdPedidoOrden { get; set; }

        public virtual TPedido? IdPedidoOrdenNavigation { get; set; }
    }
}
