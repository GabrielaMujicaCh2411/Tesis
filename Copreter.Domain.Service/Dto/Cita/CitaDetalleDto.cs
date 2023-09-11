namespace Copreter.Domain.Service.Dto.Cita
{
    public class CitaDetalleDto : CitaDto
    {
        public string Direccion { get; set; } = null!;

        public DateTime FechaInicio { get; set; }

        public int? DuracionObra { get; set; }

        public int IdUsuario { get; set; }

        public string? EstadoObra { get; set; }

        public string? Usuario { get; set; }
    }
}
