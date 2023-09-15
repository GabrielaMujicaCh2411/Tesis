using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Incidencia;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IIncidenciaService
    {
        Task<IEnumerable<TIncidencia>> ListarAsync(IncidenciaFilter model);

        Task<bool> AgregarAsync(TIncidencia entidad);

        Task<TIncidencia> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TIncidencia entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);
    }
}
