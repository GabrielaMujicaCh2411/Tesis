using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TTipoPartida
    {
        public TTipoPartida()
        {
            TPartida = new HashSet<TPartida>();
        }

        public int IdTipoPartida { get; set; }
        public string? NombreTipoPartida { get; set; }
        public string? DescripcionTipoPartida { get; set; }

        public virtual ICollection<TPartida> TPartida { get; set; }
    }
}
