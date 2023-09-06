using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class EstadoCotizacionService : BaseService, IEstadoCotizacionService
    {
        public EstadoCotizacionService(ICopreterData data) : base(data)
        {
        }


        public async Task<IEnumerable<TEstadoCotizacion>> ListarAsync()
        {
            return await this._data.EstadoCotizacion.SelectIncludes(x => x.Borrado == false);
        }
    }
}
