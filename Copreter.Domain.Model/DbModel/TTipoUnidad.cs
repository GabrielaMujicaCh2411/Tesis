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

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual ICollection<TUnidad> TUnidad { get; set; }
    }
}
