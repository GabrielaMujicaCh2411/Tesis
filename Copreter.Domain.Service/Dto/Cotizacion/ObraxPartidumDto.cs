namespace Copreter.Domain.Service.Dto.Cotizacion
{
    public class CotizarDto
    {
        public CotizarDto()
        {
            this.Lista = new List<ObraxPartidumDto>();
        }

        public bool IsIgv { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int IdObra { get; set; }
        public IEnumerable<ObraxPartidumDto> Lista { get; set; }
    }

    public class ObraxPartidumDto : BaseDto
    {
        public int IdPartida { get; set; }
        public int IdObra { get; set; }
        public decimal Metrado { get; set; }
        public string Unidad { get; set; } = null!;
        public decimal Parcial { get; set; }
    }
}
