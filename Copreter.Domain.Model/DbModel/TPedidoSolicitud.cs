using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TPedidoSolicitud
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int CantidadDias { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal PrecioSubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal IgvCalculado { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TPedido IdPedidoNavigation { get; set; } = null!;
    }
}
