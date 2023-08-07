using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TEstadoUnidad
    {
        public TEstadoUnidad()
        {
            TUnidad = new HashSet<TUnidad>();
        }

        public int IdEstadoUnidad { get; set; }
        public string? NombreEstadoUnidad { get; set; }
        public string? DescripcionEstadoUnidad { get; set; }

        public virtual ICollection<TUnidad> TUnidad { get; set; }
    }
}
