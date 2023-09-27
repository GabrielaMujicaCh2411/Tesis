namespace Copreter.Domain.Service.Dto.CotizacionxUnidad
{
    public class CotizacionxUnidadDto
    {
        public CotizacionxUnidadDto()
        {
            this.Lista = new List<AUnidadDto>();
        }

        public int IdCotizacion { get; set; }

        public IEnumerable<AUnidadDto> Lista { get; set; }
    }
}
