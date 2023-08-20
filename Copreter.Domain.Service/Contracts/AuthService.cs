using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class AuthService : BaseService, IAuthService
    {
        public AuthService(ICopreterData data) : base(data)
        {
        }

        public async Task<TUsuario> GetBy(string username, string password)
        {
            return await this._data.Usuario.FirstOrDefault(x => x.Dni.Equals(username) && x.Contrasenya.ToUpper().Equals(password));
        }
    }
}
