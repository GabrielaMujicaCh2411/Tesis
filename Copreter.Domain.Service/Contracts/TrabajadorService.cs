using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class TrabajadorService : BaseService, ITrabajadorService
    {
        public TrabajadorService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TTrabajador entidad)
        {
            var entidadActual = await this._data.Trabajador.GetById(id);
            if (entidadActual == null) return false;

            entidad.Id = entidadActual.Id;
            entidad.IdUsuarioRegistro = entidadActual.IdUsuarioRegistro;
            entidad.FechaRegistro = entidadActual.FechaRegistro;

            entidad.IdUsuarioModificacion = 2;
            entidad.FechaModificacion = DateTime.Now;

            var result = await this._data.Trabajador.Update(entidad);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TTrabajador entidad)
        {
            var result = await this._data.Trabajador.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Trabajador.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Trabajador.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TTrabajador>> ListarAsync()
        {
            return await this._data.Trabajador.SelectIncludes(x => x.Borrado == false, x => x.IdTipoTrabajadorNavigation, x => x.IdEstadoTrabajadorNavigation);
        }

        public async Task<TTrabajador> ObtenerAsync(int id)
        {
            return await this._data.Trabajador.GetById(id);
        }
    }
}
