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

        public string IdUsuario { get; set; } = null!;
        public string? Contraseña { get; set; }
        public int? DniUsuario { get; set; }
        public int? IdRolUsuario { get; set; }

        public virtual TCliente? DniUsuarioNavigation { get; set; }
        public virtual TRol? IdRolUsuarioNavigation { get; set; }
        public virtual ICollection<TObra> TObra { get; set; }
        public virtual ICollection<TPedido> TPedido { get; set; }
    }
}
