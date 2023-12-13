using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Obra;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IObraIncidenciaService
    {
        Task<IEnumerable<TObraIncidencia>> ListarAsync(ObraIndicendiaFilter model);

        Task<bool> AgregarAsync(TObraIncidencia entidad);

        Task<TObraIncidencia> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TObraIncidencia entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);
    }
}
