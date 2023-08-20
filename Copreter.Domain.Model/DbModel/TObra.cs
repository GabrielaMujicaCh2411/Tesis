using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TObra
    {
        public TObra()
        {
            TCita = new HashSet<TCita>();
            TCotizacion = new HashSet<TCotizacion>();
            TObraxPartida = new HashSet<TObraxPartida>();
        }

        public int Id { get; set; }
        public string Empresa { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string NombreObra { get; set; } = null!;
        public string? Imagen { get; set; }
        public DateTime FechaInicio { get; set; }
        public int? DuracionObra { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstadoObra { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TEstadoObra IdEstadoObraNavigation { get; set; } = null!;
        public virtual TUsuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<TCita> TCita { get; set; }
        public virtual ICollection<TCotizacion> TCotizacion { get; set; }
        public virtual ICollection<TObraxPartida> TObraxPartida { get; set; }
    }
}
