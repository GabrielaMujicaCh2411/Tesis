using Copreter.Domain.Service.Dto.Obra;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Obra
{
    public class ObraEditableVM : ObraDto
    {
        public ObraEditableVM()
        {
            this.EstadoLista = new List<SelectListItem>();
        }

        public List<SelectListItem> EstadoLista { get; set; }
    }
}
