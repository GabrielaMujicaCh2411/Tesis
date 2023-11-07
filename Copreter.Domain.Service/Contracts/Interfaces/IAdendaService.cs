using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IAdendaService
    {
        Task<bool> AgregarAsync(TAdenda entidad);

        Task<TAdenda> ObtenerAsync(int id);

        Task<TAdenda> ObtenerPorIdPedidoAsync(int idPedido);
    }
}
