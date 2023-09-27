using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.Incidencia
{
    public class IncidenciaDto : BaseDto
    {
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Incidencia { get; set; } = null!;
        [Required]
        public int HorasTrabajadas { get; set; }
        [Required]
        public int IdPedido { get; set; }

        public string? Pedido { get; set; }
    }
}
