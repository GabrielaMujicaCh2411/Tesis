using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class AccesoService : BaseService, IAccesoService
    {
        public AccesoService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TAcceso entidad)
        {
            var entidadActual = await this._data.Acceso.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdRol = entidad.IdRol;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Acceso.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(int idUsuario, TAcceso entidad)
        {
            entidad.IdUsuario = idUsuario;
            entidad.IdRol = 5;
            var result = await this._data.Acceso.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Acceso.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Acceso.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TAcceso>> ListarAsync()
        {
            return await this._data.Acceso.SelectIncludes(x => x.Borrado == false, x => x.IdRolNavigation, x => x.IdUsuarioNavigation);
        }

        public async Task<TAcceso> ObtenerAsync(int id)
        {
            return await this._data.Acceso.GetById(id);
        }
    }
}
