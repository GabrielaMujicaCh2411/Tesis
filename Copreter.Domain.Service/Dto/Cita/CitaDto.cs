namespace Copreter.Domain.Service.Dto.Cita
{
    public class CitaDto : BaseDto
    {
        public int? IdObra { get; set; }
        public string? NombreObra { get; set; } 

        public string? NombreEmpresa { get; set; }

        public string? EstadoCita { get; set; }
    }
}
