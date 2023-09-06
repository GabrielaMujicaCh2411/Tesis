using Copreter.Domain.Service.Dto.Cotizacion;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Cotizacion
{
    public class CotizacionIndexVM
    {
        public CotizacionIndexVM()
        {
            this.DtoList = new List<CotizacionDto>();

            this.Filtro = new CotizacionFilterDto();
            this.EstadoLista = new List<SelectListItem>();
        }

        public IEnumerable<CotizacionDto> DtoList { get; set; }

        public CotizacionFilterDto Filtro { get; set; }

        public List<SelectListItem> EstadoLista { get; set; }
    }
}
