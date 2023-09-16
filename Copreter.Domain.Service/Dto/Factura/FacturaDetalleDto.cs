namespace Copreter.Domain.Service.Dto.Factura
{
    public class FacturaDetalleDto : FacturaDto
    {
        public DateTime Fecha { get; set; }

        public decimal Pago { get; set; }

        public decimal Pago2 { get; set; }

        public decimal Total { get; set; }

        public int IdEstadoCotizacion { get; set; }
    }
}
