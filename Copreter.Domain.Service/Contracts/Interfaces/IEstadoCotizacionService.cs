using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IEstadoCotizacionService
    {
        Task<IEnumerable<TEstadoCotizacion>> ListarAsync();
    }
}
