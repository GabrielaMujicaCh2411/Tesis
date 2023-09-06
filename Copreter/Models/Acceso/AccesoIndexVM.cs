using Copreter.Domain.Service.Dto.Acceso;

namespace Copreter.Models.Acceso
{
    public class AccesoIndexVM
    {
        public AccesoIndexVM()
        {
            this.DtoList = new List<AccesoDto>();

            this.Filtro = new AccesoFilterDto();
        }

        public IEnumerable<AccesoDto> DtoList { get; set; }

        public AccesoFilterDto Filtro { get; set; } 
    }
}
