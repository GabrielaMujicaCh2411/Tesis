using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class OrdenServicioService : BaseService, IOrdenServicioService
    {
        public OrdenServicioService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(TOrdenServicio entidad)
        {
            var result = await this._data.OrdenServicio.Add(entidad);
            return result == 1;
        }

        public async Task<TOrdenServicio> ObtenerAsync(int id)
        {
            return await this._data.OrdenServicio.GetById(id);
        }

        public async Task<TOrdenServicio> ObtenerPorIdCotizacionAsync(int idCotizacion)
        {
            return await this._data.OrdenServicio.FirstOrDefault(x => x.IdCotizacion == idCotizacion);
        }
    }
}
