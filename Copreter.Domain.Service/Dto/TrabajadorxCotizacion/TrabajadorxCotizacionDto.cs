using Copreter.Domain.Service.Dto.Trabajador;

namespace Copreter.Domain.Service.Dto.TrabajadorxCotizacion
{
    public class TrabajadorxCotizacionDto
    {
        public TrabajadorxCotizacionDto()
        {
            this.Lista = new List<ATrabajadorDto>();
        }

        public int IdCotizacion{ get; set; }

        public IEnumerable<ATrabajadorDto> Lista { get; set; }
    }
}
