using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class TipoUnidadService : BaseService, ITipoUnidadService
    {
        public TipoUnidadService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TTipoUnidad>> ListarAsync()
        {
            return await this._data.TipoUnidad.GetAll();
        }
    }
}
