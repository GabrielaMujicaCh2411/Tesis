using Copreter.Domain.Service.Dto.Configuracion;

namespace Copreter.Models.Configuracion
{
    public class ConfiguracionIndexVM
    {
        public ConfiguracionIndexVM()
        {
            this.DtoList = new List<ConfiguracionDto>();
        }

        public IEnumerable<ConfiguracionDto> DtoList { get; set; }
    }
}
