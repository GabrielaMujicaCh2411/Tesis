using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Pedido;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<TPedido>> ListarAsync(PedidoFilter model);

        Task<TPedido> ObtenerAsync(int id);

        Task<IEnumerable<TPedidoSolicitud>> ObtenerPedidoSolicitudAsync(int idPedido);

        Task<bool> AgregarAsync(TPedido entidad, TPedidoSolicitud entidadSolicitud);

        Task<bool> ActualizarAsync(int id, TPedido entidad);

        Task<bool> ActualizarEstadoAsync(int id, int estado, int idUsuarioModificacion);

        Task<bool> EliminarAsync(int id);

        Task<int> CountAsync(int estado);

        Task<IEnumerable<TPedido>> PendienteDevolverAsync();
    }
}
