using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Domain.Service.Dto.Unidad;

namespace Copreter.Models.Trabajador
{
    public class TrabajadorIndexVM
    {
        public TrabajadorIndexVM()
        {
            this.DtoList = new List<TrabajadorDto>();
        }

        public IEnumerable<TrabajadorDto> DtoList { get; set; }
    }
}
