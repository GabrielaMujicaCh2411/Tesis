using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Pedido;

namespace Copreter.Models.Cotizacion
{
    public class CotizacionIndexVM
    {
        public CotizacionIndexVM()
        {
            this.DtoList = new List<CotizacionDto>();
        }

        public IEnumerable<CotizacionDto> DtoList { get; set; }
    }
}
