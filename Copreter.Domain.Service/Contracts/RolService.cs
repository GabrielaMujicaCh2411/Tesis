using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class RolService : BaseService, IRolService
    {
        public RolService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TRol>> ListarAsync()
        {
            return await this._data.Rol.SelectIncludes(x => x.Borrado == false);
        }
    }
}
