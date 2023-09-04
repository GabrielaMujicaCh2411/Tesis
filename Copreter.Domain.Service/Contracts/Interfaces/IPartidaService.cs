using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IPartidaService
    {
        Task<IEnumerable<TPartida>> ListarAsync();

        Task<TPartida> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TPartida entidad);

        Task<bool> ActualizarAsync(int id, TPartida entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);
    }
}
