using Copreter.Domain.Service.Dto.Obra;
using Copreter.Domain.Service.Dto.Partida;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Cotizacion
{
    public class CotizarVM
    {
        public CotizarVM()
        {
            this.Obra = new ObraDto();

            this.DtoList = new List<PartidaDto>();

            this.UnidadMedidaLista = new List<SelectListItem>();
            this.UnidadMedidaLista.Add(new SelectListItem() { Value = "Gbl" , Text = "gbl" });
            this.UnidadMedidaLista.Add(new SelectListItem() { Value = "m2", Text = "m2" });
            this.UnidadMedidaLista.Add(new SelectListItem() { Value = "und", Text = "un" });
            this.UnidadMedidaLista.Add(new SelectListItem() { Value = "ml", Text = "ml" });
        }

        public ObraDto Obra { get; set; }   

        public IEnumerable<PartidaDto> DtoList { get; set; }

        public List<SelectListItem> UnidadMedidaLista { get; set; }
    }
}
