using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IEstadoObraService
    {
        Task<IEnumerable<TEstadoObra>> ListarAsync();
    }
}
