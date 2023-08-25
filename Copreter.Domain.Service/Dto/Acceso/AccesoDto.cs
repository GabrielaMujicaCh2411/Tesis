using Copreter.Domain.Service.Dto.Cliente;

namespace Copreter.Domain.Service.Dto.Acceso
{
    public class AccesoDto : ClienteDto
    {
        public int IdRol { get; set; }

        public string? Rol { get; set; }    
    }
}
