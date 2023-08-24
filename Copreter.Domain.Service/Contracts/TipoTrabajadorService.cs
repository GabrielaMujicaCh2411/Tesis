using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class TipoTrabajadorService : BaseService, ITipoTrabajadorService
    {
        public TipoTrabajadorService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TTipoTrabajador>> ListarAsync()
        {
            return await this._data.TipoTrabajador.SelectIncludes(x => x.Borrado == false);
        }
    }
}
