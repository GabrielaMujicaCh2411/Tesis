using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TEstadoObra
    {
        public TEstadoObra()
        {
            TObra = new HashSet<TObra>();
        }

        public int IdEstadoObra { get; set; }
        public string? NombreEstadoObra { get; set; }
        public string? DescripcionEstadoObra { get; set; }

        public virtual ICollection<TObra> TObra { get; set; }
    }
}
