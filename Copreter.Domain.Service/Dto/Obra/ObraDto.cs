using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.Obra
{
    public class ObraDto : BaseDto
    {
        public string? Imagen { get; set; }
        public IFormFile? Foto { get; set; }

        [Required(ErrorMessage = "Llenar Empresa.")]
        public string Empresa { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Direccion.")]
        public string Direccion { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Nombre de Obra.")]
        public string NombreObra { get; set; } = null!;

        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Llenar Duracion de obra")]
        public int? DuracionObra { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstadoObra { get; set; }
        public string? EstadoObra { get; set; }

        //
        public string? Cliente { get; set; }
    }
}
