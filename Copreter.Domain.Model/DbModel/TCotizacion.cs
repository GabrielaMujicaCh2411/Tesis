using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TCotizacion
    {
        public TCotizacion()
        {
            TCotizacionxUnidad = new HashSet<TCotizacionxUnidad>();
            TFactura = new HashSet<TFactura>();
            TOrdenServicio = new HashSet<TOrdenServicio>();
            TPago = new HashSet<TPago>();
            TTrabajadorxCotizacion = new HashSet<TTrabajadorxCotizacion>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public bool IsIgv { get; set; }
        public decimal Igv { get; set; }
        public decimal IgvCalculado { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Saldo { get; set; }
        public int IdObra { get; set; }
        public int IdEstadoCotizacion { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TEstadoCotizacion IdEstadoCotizacionNavigation { get; set; } = null!;
        public virtual TObra IdObraNavigation { get; set; } = null!;
        public virtual ICollection<TCotizacionxUnidad> TCotizacionxUnidad { get; set; }
        public virtual ICollection<TFactura> TFactura { get; set; }
        public virtual ICollection<TOrdenServicio> TOrdenServicio { get; set; }
        public virtual ICollection<TPago> TPago { get; set; }
        public virtual ICollection<TTrabajadorxCotizacion> TTrabajadorxCotizacion { get; set; }
    }
}
