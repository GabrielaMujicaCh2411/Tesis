using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TTrabajadorxCotizacion
    {
        public int Id { get; set; }
        public int IdCotizacion { get; set; }
        public int IdTrabajador { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TCotizacion IdCotizacionNavigation { get; set; } = null!;
        public virtual TTrabajador IdTrabajadorNavigation { get; set; } = null!;
    }
}
