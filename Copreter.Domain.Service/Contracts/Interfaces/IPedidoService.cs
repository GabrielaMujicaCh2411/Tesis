using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Pedido;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<TPedido>> ListarAsync(PedidoFilter model);

        Task<TPedido> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TPedido entidad);

        Task<bool> ActualizarAsync(int id, TPedido entidad);

        Task<bool> ActualizarEstadoAsync(int id, int estado);

        Task<bool> EliminarAsync(int id);
    }
}
