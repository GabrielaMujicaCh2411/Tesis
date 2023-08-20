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

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioUnidad { get; set; }
        public int IdTipoPartida { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TTipoPartida IdTipoPartidaNavigation { get; set; } = null!;
        public virtual ICollection<TObraxPartida> TObraxPartida { get; set; }
    }
}
