using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TObraxPartida
    {
        public int Id { get; set; }
        public int IdPartida { get; set; }
        public int IdObra { get; set; }
        public decimal Metrado { get; set; }
        public string Unidad { get; set; } = null!;
        public decimal Parcial { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TObra IdObraNavigation { get; set; } = null!;
        public virtual TPartida IdPartidaNavigation { get; set; } = null!;
    }
}
