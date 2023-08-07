using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TRol
    {
        public TRol()
        {
            TUsuario = new HashSet<TUsuario>();
        }

        public int IdRol { get; set; }
        public string? NombreRol { get; set; }
        public string? DescripcionRol { get; set; }

        public virtual ICollection<TUsuario> TUsuario { get; set; }
    }
}
