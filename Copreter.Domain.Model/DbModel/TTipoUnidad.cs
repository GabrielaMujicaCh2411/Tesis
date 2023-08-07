using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TTipoUnidad
    {
        public TTipoUnidad()
        {
            TUnidad = new HashSet<TUnidad>();
        }

        public int IdTipoUnidad { get; set; }
        public string? NombreTipoUnidad { get; set; }

        public virtual ICollection<TUnidad> TUnidad { get; set; }
    }
}
