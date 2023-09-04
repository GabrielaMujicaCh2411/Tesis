using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ITipoPartidaService
    {
        Task<IEnumerable<TTipoPartida>> ListarAsync();

        Task<TTipoPartida> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TTipoPartida entidad);

        Task<bool> ActualizarAsync(int id, TTipoPartida entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);
    }
}
