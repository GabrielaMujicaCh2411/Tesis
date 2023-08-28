using Copreter.Domain.Service.Dto.Unidad;

namespace Copreter.Models.Unidad
{
    public class UnidadCatalagEditableVM
    {
        public UnidadCatalagEditableVM()
        {
            this.DtoList = new List<UnidadDto>();
        }

        public IEnumerable<UnidadDto> DtoList { get; set; }
    }
}
