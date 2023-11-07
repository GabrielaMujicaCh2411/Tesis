namespace Copreter.Domain.Service.Dto.Pago
{
    public class PagoDto : BaseDto
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal? Saldo { get; set; }
        public int IdCotizacion { get; set; }
    }
}
