using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class TipoPartidaService : BaseService, ITipoPartidaService
    {
        public TipoPartidaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(string id, TTipoPartida entidad)
        {
            var entidadActual = await this._data.TipoPartida.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.TipoPartida.Update(entidad);
            return result > 0;
        }

        public async  Task<bool> EliminarAsync(string id)
        {
            var entidadActual = await this._data.TipoPartida.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.TipoPartida.DeleteAndReturn(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TTipoPartida>> ListarAsync()
        {
            return await this._data.TipoPartida.GetAll();
        }

        public async Task<TTipoPartida> ObtenerAsync(string id)
        {
            return await this._data.TipoPartida.GetById(id);
        }
    }
}
