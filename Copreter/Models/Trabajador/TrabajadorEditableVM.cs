using Copreter.Domain.Service.Dto.Trabajador;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Trabajador
{
    public class TrabajadorEditableVM : TrabajadorDto
    {
        public TrabajadorEditableVM()
        {
            this.TipoLista = new List<SelectListItem>();
            this.EstadoLista = new List<SelectListItem>();
        }

        public List<SelectListItem> TipoLista { get; set; }

        public List<SelectListItem> EstadoLista { get; set; }
    }
}
