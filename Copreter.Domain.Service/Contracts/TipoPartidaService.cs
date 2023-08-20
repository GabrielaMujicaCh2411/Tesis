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

        public async Task<bool> ActualizarAsync(int id, TTipoPartida entidad)
        {
            var entidadActual = await this._data.TipoPartida.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.TipoPartida.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TTipoPartida entidad)
        {
            var result = await this._data.TipoPartida.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.TipoPartida.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Borrado = true;

            var result = await this._data.TipoPartida.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TTipoPartida>> ListarAsync()
        {
            return await this._data.TipoPartida.SelectIncludes(x => x.Borrado == false);
        }

        public async Task<TTipoPartida> ObtenerAsync(int id)
        {
            return await this._data.TipoPartida.GetById(id);
        }
    }
}
