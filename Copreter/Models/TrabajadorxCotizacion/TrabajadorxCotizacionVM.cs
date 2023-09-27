using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Trabajador;

namespace Copreter.Models.TrabajadorxCotizacion
{
    public class TrabajadorxCotizacionVM
    {
        public TrabajadorxCotizacionVM()
        {
            this.Cotizacion = new CotizacionDto();
            this.DtoList = new List<TrabajadorDto>();
        }

        public CotizacionDto Cotizacion { get; internal set; }
        public IEnumerable<TrabajadorDto> DtoList { get; internal set; }
        public int IdCotizacion { get; internal set; }
    }
}
