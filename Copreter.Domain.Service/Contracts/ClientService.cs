using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class ClientService : BaseService, IClienteService
    {
        public ClientService(ICopreterData data) : base(data)
        {
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

            return await this._data.Cliente.DeleteAndReturn(entidadActual) > 0;
        }

        public async Task<TCliente> ObtenerAsync(int id)
        {
            return await this._data.Cliente.GetById(id);
        }
    }
}
