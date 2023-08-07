using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TPartida
    {
        public TPartida()
        {
            TObraxPartida = new HashSet<TObraxPartida>();
        }

        public string IdPartida { get; set; } = null!;
        public string? NombrePartida { get; set; }
        public decimal? PrecioUnidad { get; set; }
        public int? IdTipoPartida { get; set; }

        public virtual TTipoPartida? IdTipoPartidaNavigation { get; set; }
        public virtual ICollection<TObraxPartida> TObraxPartida { get; set; }
    }
}
