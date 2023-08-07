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
            TPago = new HashSet<TPago>();
            DniTrabajador = new HashSet<TTrabajador>();
        }

        public string IdCotizacion { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }
        public string? IdObraCotizacion { get; set; }
        public int? IdCotizacionEstado { get; set; }

        public virtual TEstadoCotizacion? IdCotizacionEstadoNavigation { get; set; }
        public virtual TObra? IdObraCotizacionNavigation { get; set; }
        public virtual ICollection<TCotizacionxUnidad> TCotizacionxUnidad { get; set; }
        public virtual ICollection<TFactura> TFactura { get; set; }
        public virtual ICollection<TPago> TPago { get; set; }

        public virtual ICollection<TTrabajador> DniTrabajador { get; set; }
    }
}
