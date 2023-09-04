namespace Copreter.Domain.Service.Dto.Partida
{
    public class PartidaDto : BaseDto
    {
        public string Nombre { get; set; } = null!;

        public decimal PrecioUnidad { get; set; }

        public int IdTipoPartida { get; set; }

        public string? TipoPartida { get; set; }
    }
}
