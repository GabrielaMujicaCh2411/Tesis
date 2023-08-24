using Copreter.Domain.Service.Dto.Unidad;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Unidad
{
    public class UnidadEditableVM : UnidadDto
    {
        public UnidadEditableVM()
        {
            this.TipoLista = new List<SelectListItem>();
            this.EstadoLista = new List<SelectListItem>();
        }

        public List<SelectListItem> TipoLista { get; set; }

        public List<SelectListItem> EstadoLista { get; set; }
    }
}
