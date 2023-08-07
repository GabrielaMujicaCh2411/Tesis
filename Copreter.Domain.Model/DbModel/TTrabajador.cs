using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TTrabajador
    {
        public TTrabajador()
        {
            TPedido = new HashSet<TPedido>();
            IdCotizacion = new HashSet<TCotizacion>();
        }

        public int Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Celular { get; set; }
        public int? IdTipoTrabajador { get; set; }
        public int? IdEstadoTrabajador { get; set; }

        public virtual TEstadoTrabajador? IdEstadoTrabajadorNavigation { get; set; }
        public virtual TTipoTrabajador? IdTipoTrabajadorNavigation { get; set; }
        public virtual ICollection<TPedido> TPedido { get; set; }

        public virtual ICollection<TCotizacion> IdCotizacion { get; set; }
    }
}
