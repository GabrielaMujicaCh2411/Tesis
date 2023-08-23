using Copreter.Domain.Service.Dto.Unidad;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Unidad
{
    public class UnidadEditableVM : UnidadDto
    {
        public UnidadEditableVM()
        {
            this.TipoUnidadLista = new List<SelectListItem>();
            this.EstadoUnidadLista = new List<SelectListItem>();
        }

        public List<SelectListItem> TipoUnidadLista { get; set; }

        public List<SelectListItem> EstadoUnidadLista { get; set; }
    }
}
