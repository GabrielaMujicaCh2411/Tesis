using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class PagoService : BaseService, IPagoService
    {
        public PagoService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(TPago entidad)
        {
            var result = await this._data.Pago.Add(entidad);
            return result == 1;
        }

        public async Task<TPago> ObtenerAsync(int id)
        {
            return await this._data.Pago.GetById(id);
        }
    }
}
