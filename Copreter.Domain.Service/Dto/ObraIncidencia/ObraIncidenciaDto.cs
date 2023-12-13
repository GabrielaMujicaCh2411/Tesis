using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.ObraIncidencia
{
    public class ObraIncidenciaDto : BaseDto
    {
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Incidencia { get; set; } = null!;
        [Required]
        public int HorasTrabajadas { get; set; }
        [Required]
        public int IdObra { get; set; }

        public string? Obra { get; set; }
    }
}
