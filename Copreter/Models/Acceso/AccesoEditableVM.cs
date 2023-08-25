using Copreter.Domain.Service.Dto.Acceso;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Acceso
{
    public class AccesoEditableVM : AccesoDto
    {
        public AccesoEditableVM()
        {
            this.RolLista = new List<SelectListItem>();
        }

        public List<SelectListItem> RolLista { get; set; }
    }
}
