using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface ITipoPartidaService
    {
        Task<IEnumerable<TTipoPartida>> ListarAsync();

        Task<TTipoPartida> ObtenerAsync(string id);

        Task<bool> ActualizarAsync(string id, TTipoPartida entidad);

        Task<bool> EliminarAsync(string id);
    }
}
