using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.TipoPartida;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ITipoPartidaService
    {
        Task<IEnumerable<TTipoPartida>> ListarAsync(TipoPartidaFilter model);

        Task<TTipoPartida> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TTipoPartida entidad);

        Task<bool> ActualizarAsync(int id, TTipoPartida entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);
    }
}
