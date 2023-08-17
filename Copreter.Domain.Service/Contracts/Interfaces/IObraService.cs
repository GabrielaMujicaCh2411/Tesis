using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IObraService
    {
        Task<IEnumerable<TObra>> ListarAsync();

        Task<IEnumerable<TObra>> ListarPorEstadoAsync(List<int> estados);

        Task<bool> ObraPorCitadaAsync(string id);

        Task<TObra> ObtenerAsync(string id);

        Task<bool> ActualizarEstado(string id, EObraEstado estado);
    }
}
