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

        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? CantidadDias { get; set; }
        public string? Obra { get; set; }
        public string? Empresa { get; set; }
        public string? Ubicacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal? PrecioPedido { get; set; }
        public int? IdEstadoPedido { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTrabajador { get; set; }
        public int? IdUnidad { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TEstadoPedido? IdEstadoPedidoNavigation { get; set; }
        public virtual TTrabajador? IdTrabajadorNavigation { get; set; }
        public virtual TUnidad? IdUnidadNavigation { get; set; }
        public virtual TUsuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<TIncidencia> TIncidencia { get; set; }
        public virtual ICollection<TOrdenServicio> TOrdenServicio { get; set; }
    }
}
