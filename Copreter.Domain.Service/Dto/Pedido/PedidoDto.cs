using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.Pedido
{
    public class PedidoDto : BaseDto
    {
        [Required]
        public DateTime? FechaInicio { get; set; }
        [Required]
        public int? CantidadDias { get; set; }
        [Required]
        public string? Obra { get; set; }
        [Required]
        public string? Empresa { get; set; }
        [Required]
        public string? Ubicacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal? PrecioPedido { get; set; }
        public int? IdEstadoPedido { get; set; }
        public string? EstadoPedido { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTrabajador { get; set; }
        public int IdUnidad { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public decimal? PrecioUnidad { get; set; }

        //
        public int IdTipoUnidad { get; set; }
        public string? TipoUnidad { get;set; }
    }
}
