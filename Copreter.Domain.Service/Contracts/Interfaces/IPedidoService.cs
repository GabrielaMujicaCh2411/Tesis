using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<TPedido>> ListarAsync();

        Task<TPedido> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TPedido entidad);

        Task<bool> ActualizarAsync(int id, TPedido entidad);

        Task<bool> ActualizarEstadoAsync(int id, int estado);

        Task<bool> EliminarAsync(int id);
    }
}
