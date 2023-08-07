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

        public string IdObra { get; set; } = null!;
        public string? Empresa { get; set; }
        public string? Direccion { get; set; }
        public string? NombreObra { get; set; }
        public string? Imagen { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? DuracionObra { get; set; }
        public string? IdUsuarioObra { get; set; }
        public int? IdObraEstado { get; set; }

        public virtual TEstadoObra? IdObraEstadoNavigation { get; set; }
        public virtual TUsuario? IdUsuarioObraNavigation { get; set; }
        public virtual ICollection<TCita> TCita { get; set; }
        public virtual ICollection<TCotizacion> TCotizacion { get; set; }
        public virtual ICollection<TObraxPartida> TObraxPartida { get; set; }
    }
}
