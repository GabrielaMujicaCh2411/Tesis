using Copreter.Domain.Service.Dto.Usuario;

namespace Copreter.Models.Usuario
{
    public class UsuarioIndexVM
    {
        public UsuarioIndexVM()
        {
            this.DtoList = new List<UsuarioDto>();

            this.Filtro = new UsuarioFilterDto();
        }

        public IEnumerable<UsuarioDto> DtoList { get; set; }

        public UsuarioFilterDto Filtro { get; set; }
    }
}
