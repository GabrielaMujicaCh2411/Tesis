using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TCotizacionxUnidad
    {
        public string IdSerie { get; set; } = null!;
        public string IdCotizacion { get; set; } = null!;
        public int? Cantidad { get; set; }

        public virtual TCotizacion IdCotizacionNavigation { get; set; } = null!;
        public virtual TUnidad IdSerieNavigation { get; set; } = null!;
    }
}
