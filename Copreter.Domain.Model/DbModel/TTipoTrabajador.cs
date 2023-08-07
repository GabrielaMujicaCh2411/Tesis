using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TTipoTrabajador
    {
        public TTipoTrabajador()
        {
            TTrabajador = new HashSet<TTrabajador>();
        }

        public int IdTipoTrabajdor { get; set; }
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }

        public virtual ICollection<TTrabajador> TTrabajador { get; set; }
    }
}
