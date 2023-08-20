using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TOrdenServicio
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Liquidacion { get; set; }
        public int IdPedido { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TPedido IdPedidoNavigation { get; set; } = null!;
    }
}
