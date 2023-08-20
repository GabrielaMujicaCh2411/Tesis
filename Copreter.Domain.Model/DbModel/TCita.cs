using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TCita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; } = null!;
        public int IdObra { get; set; }
        public string Lugar { get; set; } = null!;
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TObra IdObraNavigation { get; set; } = null!;
    }
}
