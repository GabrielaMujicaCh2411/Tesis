using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class CotizacionService : BaseService, ICotizacionService
    {
        public CotizacionService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(TCotizacion entidad)
        {
            var result = await this._data.Cotizacion.Add(entidad);
            return result == 1;
        }

        public async Task<IEnumerable<TCotizacion>> ListarAsync()
        {
            return await this._data.Cotizacion.GetAll();
        }
    }
}
