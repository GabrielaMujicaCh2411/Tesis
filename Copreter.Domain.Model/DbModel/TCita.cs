using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TCita
    {
        public string IdCita { get; set; } = null!;
        public DateTime? FechaCita { get; set; }
        public string? HoraCita { get; set; }
        public string? IdObraCita { get; set; }
        public string? LugarCita { get; set; }

        public virtual TObra? IdObraCitaNavigation { get; set; }
    }
}
