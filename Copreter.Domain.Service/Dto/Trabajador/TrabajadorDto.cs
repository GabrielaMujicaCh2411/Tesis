using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.Trabajador
{
    public class TrabajadorDto : BaseDto
    {
        [Required(ErrorMessage = "Llenar DNI.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Dni solo numeros.")]
        public int Dni { get; set; }
        [Required(ErrorMessage = "Llenar Nombre.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nombre solo palabras.")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Apellido.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Apellido solo palabras.")]
        public string Apellido { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Celular.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Dni solo numeros.")]
        public int Celular { get; set; }
        public int IdTipoTrabajador { get; set; }
        public string? TipoTrabajador { get; set; }
        public int IdEstadoTrabajador { get; set; }
        public string? EstadoTrabajador { get; set; }
    }
}
