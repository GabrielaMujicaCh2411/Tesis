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

            entidad.Id = entidadActual.Id;
            entidad.IdUsuarioRegistro = entidadActual.IdUsuarioRegistro;
            entidad.FechaRegistro = entidadActual.FechaRegistro;

            entidad.FechaModificacion = DateTime.Now;

            var result = await this._data.Unidad.Update(entidad);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TUnidad entidad)
        {
            var result = await this._data.Unidad.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Unidad.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Unidad.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TUnidad>> ListarAsync()
        {
            return await this._data.Unidad.GetAll();
        }

        public async Task<IEnumerable<TUnidad>> ListarCatalagoAsync(int tipoUnidad)
        {
            return await this._data.Unidad.SelectIncludes(x => x.IdTipoUnidad == tipoUnidad && x.IdEstadoUnidad == 1);
        }

        public async Task<TUnidad> ObtenerAsync(int id)
        {
            return await this._data.Unidad.GetById(id);
        }
    }
}
