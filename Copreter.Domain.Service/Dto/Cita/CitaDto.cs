namespace Copreter.Domain.Service.Dto.Cita
{
    public class CitaDto : BaseDto
    {
        public DateTime Fecha { get; set; }
        
        public string Hora { get; set; } = null!;

        public int? IdObra { get; set; }

        public string Lugar { get; set; } = null!;

        public string? NombreObra { get; set; } 

        public string? NombreEmpresa { get; set; }

        public string? EstadoCita { get; set; }
    }
}
