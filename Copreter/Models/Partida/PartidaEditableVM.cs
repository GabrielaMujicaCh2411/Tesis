using Copreter.Domain.Service.Dto.Partida;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Models.Partida
{
    public class PartidaEditableVM : PartidaDto
    {
        public PartidaEditableVM()
        {
            this.TipoLista = new List<SelectListItem>();
        }

        public List<SelectListItem> TipoLista { get; set; }
    }
}
