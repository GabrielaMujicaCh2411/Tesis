using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TEstadoCotizacion
    {
        public TEstadoCotizacion()
        {
            TCotizacion = new HashSet<TCotizacion>();
        }

        public int IdEstadoCotizacion { get; set; }
        public string? NombreEstadoCotizacion { get; set; }
        public string? DescripcionEstadoCotizacion { get; set; }

        public virtual ICollection<TCotizacion> TCotizacion { get; set; }
    }
}
