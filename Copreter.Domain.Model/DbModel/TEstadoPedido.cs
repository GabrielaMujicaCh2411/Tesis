using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TEstadoPedido
    {
        public TEstadoPedido()
        {
            TPedido = new HashSet<TPedido>();
        }

        public int IdEstadoPedido { get; set; }
        public string? NombreEstadoPedido { get; set; }
        public string? DescripcionEstadoPedido { get; set; }

        public virtual ICollection<TPedido> TPedido { get; set; }
    }
}
