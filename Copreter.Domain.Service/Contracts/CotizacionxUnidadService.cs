using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class CotizacionxUnidadService : BaseService, ICotizacionxUnidadService
    {
        public CotizacionxUnidadService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(IEnumerable<TCotizacionxUnidad> entidades)
        {
            foreach (var entidade in entidades)
            {
                entidade.Id = 0;
            }

            await this._data.CotizacionXUnidad.AddRange(entidades);
            return true;
        }
    }
}
