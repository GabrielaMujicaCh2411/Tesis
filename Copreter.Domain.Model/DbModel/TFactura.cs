using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TFactura
    {
        public string IdFactura { get; set; } = null!;
        public string? Imagen { get; set; }
        public string? IdCotizacionFactura { get; set; }

        public virtual TCotizacion? IdCotizacionFacturaNavigation { get; set; }
    }
}
