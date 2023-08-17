using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<TRol>> ListarAsync();
    }
}
