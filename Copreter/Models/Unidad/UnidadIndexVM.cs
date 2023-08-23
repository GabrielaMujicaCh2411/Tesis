using Copreter.Domain.Service.Dto.Cliente;
using Copreter.Domain.Service.Dto.Unidad;

namespace Copreter.Models.Unidad
{
    public class UnidadIndexVM
    {
        public UnidadIndexVM()
        {
            this.DtoList = new List<UnidadDto>();
        }

        public IEnumerable<UnidadDto> DtoList { get; set; }
    }
}
