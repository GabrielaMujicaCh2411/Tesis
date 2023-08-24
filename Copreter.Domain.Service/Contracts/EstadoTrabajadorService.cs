using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class EstadoTrabajadorService : BaseService, IEstadoTrabajadorService
    {
        public EstadoTrabajadorService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TEstadoTrabajador>> ListarAsync()
        {
            return await this._data.EstadoTrabajador.SelectIncludes(x => x.Borrado == false);
        }
    }
}
