using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Obra;

namespace Copreter.Models.Cotizacion
{
    public class CotizacionEditableVM : CotizacionDto
    {
        public CotizacionEditableVM()
        {
            this.ObraPartidaLista = new List<ObraPartidaDto>();
        }

        public string? Empresa { get; set; }

        public string? Direccion { get; set; }  

        public DateTime Fecha { get; set; }

        public IEnumerable<ObraPartidaDto> ObraPartidaLista { get; set; }
    }
}
