using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Domain.Service.Dto.Unidad;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Trabajador
{
    public class TrabajadorIndexVM
    {
        public TrabajadorIndexVM()
        {
            this.DtoList = new List<TrabajadorDto>();

            this.Filtro = new TrabajadorFilterDto();
            this.TipoLista = new List<SelectListItem>();
            this.EstadoLista = new List<SelectListItem>();
        }

        public IEnumerable<TrabajadorDto> DtoList { get; set; }

        public TrabajadorFilterDto Filtro { get; set; }

        public List<SelectListItem> TipoLista { get; set; }

        public List<SelectListItem> EstadoLista { get; set; }
    }
}
