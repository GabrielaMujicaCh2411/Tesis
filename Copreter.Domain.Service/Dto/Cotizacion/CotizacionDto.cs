namespace Copreter.Domain.Service.Dto.Cotizacion
{
    public class CotizacionDto : BaseDto
    {
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdObra { get; set; }
        public int IdEstadoCotizacion { get; set; }
        public string? EstadoCotizacion { get; set; }
    }
}
