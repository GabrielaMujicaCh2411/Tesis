using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TPago
    {
        public string IdPago { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public decimal? Pago1 { get; set; }
        public decimal? Pago2 { get; set; }
        public string? IdCotizacionPago { get; set; }

        public virtual TCotizacion? IdCotizacionPagoNavigation { get; set; }
    }
}
