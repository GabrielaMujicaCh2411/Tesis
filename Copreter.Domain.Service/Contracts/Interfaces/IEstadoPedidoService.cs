using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IEstadoPedidoService
    {
        Task<IEnumerable<TEstadoPedido>> ListarAsync();
    }
}
