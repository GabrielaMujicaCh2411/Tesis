using Microsoft.AspNetCore.Http;

namespace Copreter.Domain.Service.Dto.OrdenServicio
{
    public class OrdenServicioDto : BaseDto
    {
        public string? Imagen { get; set; }
        public int IdObra { get; set; }
        public int IdCotizacion { get; set; }
        public IFormFile? Foto { get; set; }
    }
}
