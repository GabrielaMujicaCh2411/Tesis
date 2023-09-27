using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.CotizacionxUnidad;

namespace Copreter.Models.CotizacionxUnidad
{
    public class CotizacionxUnidadVM
    {
        public CotizacionxUnidadVM()
        {
            this.Cotizacion = new CotizacionDto();
            this.DtoList = new List<AUnidadDto>();
        }

        public CotizacionDto Cotizacion { get; internal set; }
        public IEnumerable<AUnidadDto> DtoList { get; internal set; }
        public int IdCotizacion { get; internal set; }
    }
}
