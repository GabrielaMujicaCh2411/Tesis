using Copreter.Domain.Service.Dto.Cliente;

namespace Copreter.Models.Cliente
{
    public class ClienteIndexVM
    {
        public ClienteIndexVM()
        {
            this.DtoList = new List<ClienteDto>();
        }

        public IEnumerable<ClienteDto> DtoList { get; set; }
    }
}
