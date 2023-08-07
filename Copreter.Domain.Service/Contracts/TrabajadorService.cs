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

            var result = await this._data.Trabajador.Update(entidad);
            return result > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Trabajador.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Trabajador.DeleteAndReturn(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TTrabajador>> ListarAsync()
        {
           return await this._data.Trabajador.GetAll();
        }

        public async Task<TTrabajador> ObtenerAsync(int id)
        {
            return await this._data.Trabajador.GetById(id);
        }
    }
}
