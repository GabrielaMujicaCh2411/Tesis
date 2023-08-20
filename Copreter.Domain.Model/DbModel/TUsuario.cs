using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TObra = new HashSet<TObra>();
            TPedido = new HashSet<TPedido>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Contrasenya { get; set; } = null!;
        public int Dni { get; set; }
        public int IdRol { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TRol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<TObra> TObra { get; set; }
        public virtual ICollection<TPedido> TPedido { get; set; }
    }
}
