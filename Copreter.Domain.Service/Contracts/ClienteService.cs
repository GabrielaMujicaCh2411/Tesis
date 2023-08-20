using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class ClienteService : BaseService, IClienteService
    {
        public ClienteService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TCliente>> ListarAsync()
        {
            return await this._data.Cliente.SelectIncludes(x => x.Borrado == false);
        }

        public async Task<bool> ActualizarAsync(int id, TCliente entidad)
        {
            var entidadActual = await this._data.Cliente.GetById(id);
            if (entidadActual == null) return false;

            entidad.Dni = entidadActual.Dni;

            var result = await this._data.Cliente.Update(entidad);
            return result == 1;
        }

        public async Task<bool> AgregarAsync(TCliente entidad)
        {
            var result = await this._data.Cliente.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Cliente.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Borrado = true;

            var result = await this._data.Cliente.Update(entidadActual);
            return result == 1;
        }

        public async Task<TCliente> ObtenerAsync(int id)
        {
            return await this._data.Cliente.GetById(id);
        }
    }
}
