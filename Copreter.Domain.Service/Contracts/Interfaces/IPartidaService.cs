using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IPartidaService
    {
        Task<IEnumerable<TPartida>> ListarAsync();

        Task<TPartida> ObtenerAsync(string id);

        Task<bool> AgregarAsync(TPartida entidad);

        Task<bool> ActualizarAsync(string id, TPartida entidad);
    }
}
