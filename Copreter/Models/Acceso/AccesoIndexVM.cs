using Copreter.Domain.Service.Dto.Acceso;

namespace Copreter.Models.Acceso
{
    public class AccesoIndexVM
    {
        public AccesoIndexVM()
        {
            this.DtoList = new List<AccesoDto>();
        }

        public IEnumerable<AccesoDto> DtoList { get; set; }
    }
}
