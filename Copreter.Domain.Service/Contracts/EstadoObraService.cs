using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class EstadoObraService : BaseService, IEstadoObraService
    {
        public EstadoObraService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TEstadoObra>> ListarAsync()
        {
            return await this._data.EstadoObra.SelectIncludes(x => x.Borrado == false);
        }
    }
}
