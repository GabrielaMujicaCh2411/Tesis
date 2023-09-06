using Copreter.Domain.Service.Dto.Obra;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Obra
{
    public class ObraIndexVM
    {
        public ObraIndexVM()
        {
            this.DtoList = new List<ObraDto>();

            this.Filtro = new ObraFilterDto();
            this.EstadoLista = new List<SelectListItem>();
        }

        public IEnumerable<ObraDto> DtoList { get; set; }

        public ObraFilterDto Filtro { get; set; }

        public List<SelectListItem> EstadoLista { get; set; }
    }
}
