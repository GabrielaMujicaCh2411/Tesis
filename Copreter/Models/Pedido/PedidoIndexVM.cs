using Copreter.Domain.Service.Dto.Pedido;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Pedido
{
    public class PedidoIndexVM
    {
        public PedidoIndexVM()
        {
            this.DtoList = new List<PedidoDto>();
            this.MostrarFiltro = true;

            this.Filtro = new PedidoFilterDto();
            this.EstadoLista = new List<SelectListItem>();
        }

        public IEnumerable<PedidoDto> DtoList { get; set; }

        public bool MostrarFiltro { get; set; }

        public PedidoFilterDto Filtro { get; set; }

        public List<SelectListItem> EstadoLista { get; set; }
    }
}
