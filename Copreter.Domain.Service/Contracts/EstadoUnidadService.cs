using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class EstadoUnidadService : BaseService, IEstadoUnidadService
    {
        public EstadoUnidadService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TEstadoUnidad>> ListarAsync()
        {
            return await this._data.EstadoUnidad.SelectIncludes(x => x.Borrado == false);
        }
    }
}
