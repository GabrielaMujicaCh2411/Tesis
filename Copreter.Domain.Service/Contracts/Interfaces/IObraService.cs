using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IObraService
    {
        Task<IEnumerable<TObra>> ListarAsync();

        Task<IEnumerable<TObra>> ListarPorEstadoAsync(List<int> estados);

        Task<bool> ObraPorCitaAsync(int id);

        Task<TObra> ObtenerAsync(int id);

        Task<bool> ActualizarEstado(int id, EObraEstado estado);
    }
}
