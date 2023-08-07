using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TIncidencia
    {
        public string IdIncidencia { get; set; } = null!;
        public DateTime? FechaHorario { get; set; }
        public string? Incidencia { get; set; }
        public int? HorasTrabajadas { get; set; }
        public string? IdPedidoIncidencia { get; set; }

        public virtual TPedido? IdPedidoIncidenciaNavigation { get; set; }
    }
}
