using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Auth;

namespace Copreter.Domain.Service.Contracts
{
    internal class AuthService : BaseService, IAuthService
    {
        public AuthService(ICopreterData data) : base(data)
        {
        }

        public async Task<TAcceso> GetBy(LoginDto model)
        {
            return await this._data.Acceso.FirstOrDefault(x => x.Email.ToUpper().Equals(model.Email.ToUpper()) && x.Contrasenya.ToUpper().Equals(model.Password));
        }
    }
}
