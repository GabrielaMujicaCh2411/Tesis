namespace Copreter.Domain.Service.Dto.TipoPartida
{
    public class TipoPartidaDto: BaseDto
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
