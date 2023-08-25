using Copreter.Domain.Service.Dto.Usuario;

namespace Copreter.Models.Usuario
{
    public class UsuarioIndexVM
    {
        public UsuarioIndexVM()
        {
            this.DtoList = new List<UsuarioDto>();
        }

        public IEnumerable<UsuarioDto> DtoList { get; set; }
    }
}
