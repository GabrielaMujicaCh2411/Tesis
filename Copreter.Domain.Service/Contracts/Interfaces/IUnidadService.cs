using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IUnidadService
    {
        Task<IEnumerable<TUnidad>> ListarAsync();

        Task<IEnumerable<TUnidad>> ListarCatalagoAsync(int tipoUnidad);

        Task<TUnidad> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TUnidad entidad);

        Task<bool> EliminarAsync(int id);
    }
}
