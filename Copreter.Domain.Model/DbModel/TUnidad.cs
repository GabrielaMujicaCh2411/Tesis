using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TUnidad
    {
        public TUnidad()
        {
            TCotizacionxUnidad = new HashSet<TCotizacionxUnidad>();
            TPedido = new HashSet<TPedido>();
        }

        public int Id { get; set; }
        public string Serie { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Caracteristica1 { get; set; } = null!;
        public string? Caracteristica2 { get; set; }
        public string? Caracteristica3 { get; set; }
        public int IdTipoUnidad { get; set; }
        public int IdEstadoUnidad { get; set; }
        public string? Imagen { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TEstadoUnidad IdEstadoUnidadNavigation { get; set; } = null!;
        public virtual TTipoUnidad IdTipoUnidadNavigation { get; set; } = null!;
        public virtual ICollection<TCotizacionxUnidad> TCotizacionxUnidad { get; set; }
        public virtual ICollection<TPedido> TPedido { get; set; }
    }
}
