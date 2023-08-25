using Copreter.Domain.Service.Dto.Cliente;

namespace Copreter.Domain.Service.Dto.Usuario
{
    public class UsuarioDto : ClienteDto
    {
        public int IdRol { get; set; }

        public string? Rol { get; set; }    
    }
}
