namespace Copreter.Domain.Service.Dto.Cotizacion
{
    public class CotizacionDto : BaseDto
    {
        public DateTime Fecha { get; set; }
        public decimal Igv { get; set; }

        public decimal IgvCalculado { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int IdObra { get; set; }
        public string? Obra { get; set; }
        public int IdEstadoCotizacion { get; set; }
        public string? EstadoCotizacion { get; set; }
    }
}
