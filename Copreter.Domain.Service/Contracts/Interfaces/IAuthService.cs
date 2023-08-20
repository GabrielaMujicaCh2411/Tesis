using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IAuthService
    {
        Task<TUsuario> GetBy(string username, string password);
    }
}
