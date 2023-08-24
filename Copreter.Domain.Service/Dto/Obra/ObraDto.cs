namespace Copreter.Domain.Service.Dto.Obra
{
    public class ObraDto : BaseDto
    {
        public string Empresa { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string NombreObra { get; set; } = null!;
        public string? Imagen { get; set; }
        public DateTime FechaInicio { get; set; }
        public int? DuracionObra { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstadoObra { get; set; }
    }
}
