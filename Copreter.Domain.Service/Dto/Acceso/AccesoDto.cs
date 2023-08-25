using Copreter.Domain.Service.Dto.Usuario;

namespace Copreter.Domain.Service.Dto.Acceso
{
    public class AccesoDto : UsuarioDto
    {
        public int IdRol { get; set; }

        public string? Rol { get; set; }    
    }
}
