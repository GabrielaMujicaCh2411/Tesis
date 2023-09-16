using Microsoft.AspNetCore.Http;

namespace Copreter.Domain.Service.Dto.Factura
{
    public class FacturaDto : BaseDto
    {
        public string? Imagen { get; set; }
        public int IdCotizacion { get; set; }
        public IFormFile? Foto { get; set; }
    }
}
