using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TObraxPartida
    {
        public string IdPartida { get; set; } = null!;
        public string IdObra { get; set; } = null!;
        public decimal? Metrado { get; set; }
        public string? Unidad { get; set; }
        public decimal? Parcial { get; set; }

        public virtual TObra IdObraNavigation { get; set; } = null!;
        public virtual TPartida IdPartidaNavigation { get; set; } = null!;
    }
}
