using Microsoft.AspNetCore.Http;

namespace Copreter.Domain.Service.Dto.Adenda
{
    public class AdendaDto : BaseDto
    {
        public string? Imagen { get; set; }
        public int IdObra { get; set; }
        public IFormFile? Foto { get; set; }
    }
}
