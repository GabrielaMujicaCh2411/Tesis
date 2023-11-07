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

        public async Task<TFactura> ObtenerAsync(int id)
        {
            return await this._data.Factura.FirstOrDefault(x => x.Id == id, x => x.IdCotizacionNavigation);
        }

        public async Task<TFactura> ObtenerPorIdCotizacionAsync(int idCotizacion)
        {
            return await this._data.Factura.FirstOrDefault(x => x.IdCotizacion == idCotizacion, x => x.IdCotizacionNavigation);
        }
    }
}
