using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Model.Obra;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IObraService
    {
        Task<IEnumerable<TObra>> ListarAsync(ObraFilter model);

        Task<IEnumerable<TObra>> ListarPorEstadoAsync(List<int> estados);

        Task<bool> AgregarAsync(TObra entidad);

        Task<TObra> ObtenerAsync(int id);

        Task<bool> ActualizarEstadoAsync(int id, int estado, int idUsuarioModificacion);

        Task<int> CountAsync(int idEstado);
    }
}
