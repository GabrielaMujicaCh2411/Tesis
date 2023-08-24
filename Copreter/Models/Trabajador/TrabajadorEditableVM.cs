using Copreter.Domain.Service.Dto.Trabajador;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Trabajador
{
    public class TrabajadorEditableVM : TrabajadorDto
    {
        public TrabajadorEditableVM()
        {
            this.TipoTrabajadorLista = new List<SelectListItem>();
            this.EstadoTrabajadorLista = new List<SelectListItem>();
        }

        public List<SelectListItem> TipoTrabajadorLista { get; set; }

        public List<SelectListItem> EstadoTrabajadorLista { get; set; }
    }
}
