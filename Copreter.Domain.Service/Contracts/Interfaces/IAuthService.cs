using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Auth;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IAuthService
    {
        Task<TAcceso> GetBy(LoginDto model);
    }
}
