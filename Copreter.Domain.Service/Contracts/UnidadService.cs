using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class UnidadService : BaseService, IUnidadService
    {
        public UnidadService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TUnidad entidad)
        {
            var entidadActual = await this._data.Unidad.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Unidad.Update(entidad);
            return result > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Unidad.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Unidad.DeleteAndReturn(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TUnidad>> ListarAsync()
        {
            return await this._data.Unidad.GetAll();
        }

        public async Task<IEnumerable<TUnidad>> ListarCatalagoAsync(int tipoUnidad)
        {
            return await this._data.Unidad.SelectIncludes(x=> x.IdTipoUnidad == tipoUnidad && x.IdEstadoUnidad == 1);
        }

        public async Task<TUnidad> ObtenerAsync(int id)
        {
            return await this._data.Unidad.GetById(id);
        }
    }
}
