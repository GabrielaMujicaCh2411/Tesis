using Copreter.Domain.Service.Dto.PedidoOrdenServicio;

namespace Copreter.Models.PedidoOrdenServicio
{
    public class PedidoOrdenServicioVM
    {
        public PedidoOrdenServicioVM()
        {
            this.DtoList = new List<PedidoOrdenServicioDto>();
        }

        public IEnumerable<PedidoOrdenServicioDto> DtoList { get; set; }
    }
}
