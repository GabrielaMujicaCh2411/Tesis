using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.Unidad
{
    public class UnidadDto : BaseDto
    {
        [Required(ErrorMessage = "Llenar Serie.")]
        public string Serie { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Nombre.")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Modelo.")]
        public string Modelo { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Marca.")]
        public string Marca { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Precio.")]
        [RegularExpression(@"^\d{0,4}(\.\d{1,2})?$", ErrorMessage = "Formato de Precio Invalido.")]
        public decimal Precio { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Cantidad solo numeros.")]
        [Required(ErrorMessage = "Llenar Cantidad.")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Llenar Descripcion.")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Caracteristica.")]
        public string Caracteristica1 { get; set; } = null!;
        [Required(ErrorMessage = "Llenar Segunda Caracteristica.")]
        public string? Caracteristica2 { get; set; }
        [Required(ErrorMessage = "Llenar Tercera Categoria.")]
        public string? Caracteristica3 { get; set; }
        public int IdTipoUnidad { get; set; }
        public string? TipoUnidad { get; set; }
        public int IdEstadoUnidad { get; set; }
        public string? EstadoUnidad { get; set; }
        public string? Imagen { get; set; }
        public IFormFile? Foto { get; set; }

        public int? CantidadDisponible { get; set; }
    }
}
