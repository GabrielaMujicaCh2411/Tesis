using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class ObraService : BaseService, IObraService
    {
        public ObraService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TObra>> ListarAsync()
        {
            return await this._data.Obra.SelectIncludes(x => x.Borrado == false);
        }

        public async Task<IEnumerable<TObra>> ListarPorEstadoAsync(List<int> estados)
        {
            return await this._data.Obra.SelectIncludes(x => estados.Contains(x.IdEstadoObra));
        }

        public async Task<bool> ActualizarEstado(int id, EObraEstado estado)
        {
            var result = await this._data.Obra.GetById(id);
            if (result == null) return false;

            result.IdEstadoObra = (int)estado;

            return await this._data.Obra.Update(result) > 0;
        }

        public async Task<bool> ObraPorCitaAsync(int id)
        {
            var result = await this._data.Obra.GetById(id);
            if (result == null) return false;

            result.IdEstadoObra = 1;

            return await this._data.Obra.Update(result) > 0;
        }

        public async Task<TObra> ObtenerAsync(int id)
        {
            return await this._data.Obra.GetById(id);
        }
    }
}
