﻿namespace Copreter.Domain.Service.Dto.Pedido
{
    public class PedidoDto : BaseDto
    {
        public DateTime? FechaInicio { get; set; }
        public int? CantidadDias { get; set; }
        public string? Obra { get; set; }
        public string? Empresa { get; set; }
        public string? Ubicacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal? PrecioPedido { get; set; }
        public int? IdEstadoPedido { get; set; }
        public string? EstadoPedido { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTrabajador { get; set; }
        public int? IdUnidad { get; set; }
    }
}