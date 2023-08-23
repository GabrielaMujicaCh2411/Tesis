using Copreter.Domain.Service.Dto.Pedido;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Pedido
{
    public class PedidoEditableVM : PedidoDto
    {
        public PedidoEditableVM()
        {
            this.TrabajadorLista = new List<SelectListItem>();
        }

        public List<SelectListItem> TrabajadorLista { get; set; }
    }
}
