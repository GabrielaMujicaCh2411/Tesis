using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TCliente
    {
        public TCliente()
        {
            TUsuario = new HashSet<TUsuario>();
        }

        public int Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<TUsuario> TUsuario { get; set; }
    }
}
