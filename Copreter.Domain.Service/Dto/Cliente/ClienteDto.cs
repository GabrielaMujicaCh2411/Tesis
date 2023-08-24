using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.Cliente
{
    public class ClienteDto: BaseDto
    {
        public int Id { get; set; }

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

        [Required(ErrorMessage = "Llenar Correo.")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Formato Email Incorrecto.")]
        public string Correo { get; set; } = null!;

        [Required(ErrorMessage = "Llenar Direccion.")]
        public string Direccion { get; set; } = null!;
    }
}
