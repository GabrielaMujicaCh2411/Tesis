namespace Copreter.Domain.Service.Dto.Trabajador
{
    public class TrabajadorDto : BaseDto
    {
        public int Dni { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Celular { get; set; }
        public int IdTipoTrabajador { get; set; }
        public string? TipoTrabajador { get; set; }
        public int IdEstadoTrabajador { get; set; }
        public string? EstadoTrabajador { get; set; }
    }
}
