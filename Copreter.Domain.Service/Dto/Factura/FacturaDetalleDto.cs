namespace Copreter.Domain.Service.Dto.Factura
{
    public class FacturaDetalleDto : FacturaDto
    {
        public DateTime Fecha { get; set; }

        public decimal Monto { get; set; }

        public decimal Saldo { get; set; }

        public decimal Total { get; set; }

        public int IdEstadoCotizacion { get; set; }
    }
}
