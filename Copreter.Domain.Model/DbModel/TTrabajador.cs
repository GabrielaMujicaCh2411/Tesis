using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TTrabajador
    {
        public TTrabajador()
        {
            TPedido = new HashSet<TPedido>();
            TTrabajadorxCotizacion = new HashSet<TTrabajadorxCotizacion>();
        }

        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Celular { get; set; }
        public int IdTipoTrabajador { get; set; }
        public int IdEstadoTrabajador { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TEstadoTrabajador IdEstadoTrabajadorNavigation { get; set; } = null!;
        public virtual TTipoTrabajador IdTipoTrabajadorNavigation { get; set; } = null!;
        public virtual ICollection<TPedido> TPedido { get; set; }
        public virtual ICollection<TTrabajadorxCotizacion> TTrabajadorxCotizacion { get; set; }
    }
}
