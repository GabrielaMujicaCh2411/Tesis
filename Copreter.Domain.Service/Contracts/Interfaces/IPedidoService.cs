using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface IPedidoService
    {
        Task<IEnumerable<TPedido>> ListarAsync();

        Task<TPedido> ObtenerAsync(string id);

        Task<bool> AgregarAsync(TPedido entidad);

        Task<bool> ActualizarAsync(string id, TPedido entidad);

        Task<bool> ActualizarEstadoAsync(string id, int estado);

        Task<bool> EliminarAsync(string id);
    }
}
