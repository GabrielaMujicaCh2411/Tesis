using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TEstadoTrabajador
    {
        public TEstadoTrabajador()
        {
            TTrabajador = new HashSet<TTrabajador>();
        }

        public int IdEstadoTrabajador { get; set; }
        public string? NombreEstadoTrabajador { get; set; }
        public string? DescripcionEstadoTrabajador { get; set; }

        public virtual ICollection<TTrabajador> TTrabajador { get; set; }
    }
}
