using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IEstadoUnidadService
    {
        Task<IEnumerable<TEstadoUnidad>> ListarAsync();
    }
}
