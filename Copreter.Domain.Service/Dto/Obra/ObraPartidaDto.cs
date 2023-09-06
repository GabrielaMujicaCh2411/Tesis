namespace Copreter.Domain.Service.Dto.Obra
{
    public class ObraPartidaDto : BaseDto
    {
        public int IdPartida { get; set; }
        public string? Partida { get; set; }
        public int IdObra { get; set; }
        public decimal Metrado { get; set; }
        public string Unidad { get; set; } = null!;
        public decimal Parcial { get; set; }
    }
}
