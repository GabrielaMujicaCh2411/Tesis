using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface IPartidaService
    {
        Task<IEnumerable<TPartida>> ListarAsync();

        Task<IEnumerable<TTipoPartida>> ListarTipoPartidaAsync();

        Task<TPartida> ObtenerAsync(string id);

        Task<bool> AgregarAsync(TPartida entidad);

        Task<bool> ActualizarAsync(string id, TPartida entidad);
    }
}
