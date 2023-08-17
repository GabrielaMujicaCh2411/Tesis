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

        public async Task<bool> ActualizarAsync(string id, TUsuario entidad)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Usuario.Update(entidad);
            return result > 0;
        }

        public async Task<bool> CrearAsync(TUsuario entidad)
        {
            var result = await this._data.Usuario.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(string id)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Usuario.DeleteAndReturn(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TUsuario>> ListarAsync()
        {
            return await this._data.Usuario.GetAll();
        }

        public async Task<TUsuario> ObtenerAsync(string id)
        {
            return await this._data.Usuario.GetById(id);
        }
    }
}
