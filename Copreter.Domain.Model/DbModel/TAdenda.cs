using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TAdenda
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public string? Imagen { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TPedido IdPedidoNavigation { get; set; } = null!;
    }
}
