namespace Copreter.Domain.Service.Dto.Pago
{
    public class PagoDto : BaseDto
    {
        public DateTime Fecha { get; set; }
        public decimal Pago1 { get; set; }
        public decimal? Pago2 { get; set; }
        public int IdCotizacion { get; set; }
    }
}
