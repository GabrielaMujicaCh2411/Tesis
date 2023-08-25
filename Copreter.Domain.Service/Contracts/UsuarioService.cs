using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class UsuarioService : BaseService, IUsuarioService
    {
        public UsuarioService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TUsuario>> ListarAsync()
        {
            return await this._data.Usuario.SelectIncludes(x => x.Borrado == false);
        }

        public async Task<bool> ActualizarAsync(int id, TUsuario entidad)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Nombre = entidad.Nombre;
            entidadActual.Apellido = entidad.Apellido;
            entidadActual.Celular = entidad.Celular;
            entidadActual.Direccion = entidad.Direccion;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;


            var result = await this._data.Usuario.Update(entidad);
            return result == 1;
        }

        public async Task<TUsuario> AgregarAsync(TUsuario entidad)
        {
            var result = await this._data.Usuario.AddAndReturn(entidad);
            return result != null ? result : null;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Borrado = true;

            var result = await this._data.Usuario.Update(entidadActual);
            return result == 1;
        }

        public async Task<TUsuario> ObtenerAsync(int id)
        {
            return await this._data.Usuario.GetById(id);
        }
    }
}
