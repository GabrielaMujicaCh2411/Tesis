using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TAcceso = new HashSet<TAcceso>();
            TObra = new HashSet<TObra>();
            TPedido = new HashSet<TPedido>();
        }

        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Celular { get; set; }
        public string Email { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual ICollection<TAcceso> TAcceso { get; set; }
        public virtual ICollection<TObra> TObra { get; set; }
        public virtual ICollection<TPedido> TPedido { get; set; }
    }
}
