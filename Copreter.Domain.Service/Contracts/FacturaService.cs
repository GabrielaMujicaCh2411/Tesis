using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class FacturaService : BaseService, IFacturaService
    {
        public FacturaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(TFactura entidad)
        {
            var result = await this._data.Factura.Add(entidad);
            return result == 1;
        }
    }
}
