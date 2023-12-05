using Microsoft.AspNetCore.Http;

namespace Copreter.Domain.Service.Dto.PedidoOrdenServicio
{
    public class PedidoOrdenServicioDto : BaseDto
    {
        public string? Imagen { get; set; }
        public int IdPedido { get; set; }
        public IFormFile? Foto { get; set; }
    }
}
