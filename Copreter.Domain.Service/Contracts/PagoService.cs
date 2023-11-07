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

        public async Task<TPago> ObtenerPoIdCotizacionAsync(int idCotizacion)
        {
            return await this._data.Pago.FirstOrDefault(x=> x.IdCotizacion == idCotizacion);
        }

        public async Task<decimal> DineroEnMesAsync()
        {
            var currentDate = DateTime.Now;

            var result = await this._data.Pago.SelectIncludes(x => x.FechaRegistro >= new DateTime(currentDate.Year, currentDate.Month, 1, 0, 0, 0) && x.FechaRegistro >= new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 00));

            return result != null ? result.Sum(x => x.Monto) : 0;
        }
    }
}
