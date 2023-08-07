using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TPedido
    {
        public TPedido()
        {
            TIncidencia = new HashSet<TIncidencia>();
            TOrdenServicio = new HashSet<TOrdenServicio>();
        }

        public string IdPedido { get; set; } = null!;
        public DateTime? FechaInicio { get; set; }
        public int? CantidadDias { get; set; }
        public string? Obra { get; set; }
        public string? Empresa { get; set; }
        public string? Ubicacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal? PrecioPedido { get; set; }
        public int? IdEstadoPedido { get; set; }
        public string? IdUsuarioPedido { get; set; }
        public int? IdTrabajadorPedido { get; set; }
        public string? IdUnidadPedido { get; set; }

        public virtual TEstadoPedido? IdEstadoPedidoNavigation { get; set; }
        public virtual TTrabajador? IdTrabajadorPedidoNavigation { get; set; }
        public virtual TUnidad? IdUnidadPedidoNavigation { get; set; }
        public virtual TUsuario? IdUsuarioPedidoNavigation { get; set; }
        public virtual ICollection<TIncidencia> TIncidencia { get; set; }
        public virtual ICollection<TOrdenServicio> TOrdenServicio { get; set; }
    }
}
