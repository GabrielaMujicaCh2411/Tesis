using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Model.Unidad;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IUnidadService
    {
        Task<IEnumerable<TUnidad>> ListarAsync(UnidadFilter model);

        Task<IEnumerable<TUnidad>> ListarCatalagoAsync(int tipoUnidad);

        Task<TUnidad> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TUnidad entidad);

        Task<bool> ActualizarAsync(int id, TUnidad entidad);

        Task<bool> ActualizarCantidadAsync(int id, int entidad);

        Task<bool> EliminarAsync(int id);

        Task<int> CountAsync(int idEstado);

        Task<bool> ActualizarEstadoAsync(IEnumerable<TUnidad> enumerable, EUnidadEstado noDisponible, int v);
    }
}
