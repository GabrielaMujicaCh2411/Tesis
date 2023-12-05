using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IPedidoOrdenServicioService
    {
        Task<bool> AgregarAsync(TPedidoOrdenServicio entidad);

        Task<TPedidoOrdenServicio> ObtenerAsync(int id);

        Task<IEnumerable<TPedidoOrdenServicio>> ObtenerPorIdPedidoAsync(int IdPedido);

        Task<TPedidoOrdenServicio> ObtenerPorIdAsync(int id);
    }
}
