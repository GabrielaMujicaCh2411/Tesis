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
            return await this._data.Obra.GetAllOrder(x => x.IdObra, System.ComponentModel.ListSortDirection.Descending);
        }

        public async Task<IEnumerable<TObra>> ListarPorEstadoAsync(List<int> estados)
        {
            return await this._data.Obra.SelectIncludes(x => estados.Contains(x.IdObraEstado.Value));
        }

        public async Task<bool> ActualizarEstado(string id, EObraEstado estado)
        {
            var result = await this._data.Obra.GetById(id);
            if (result == null) return false;

            result.IdObraEstado = (int)estado;

            return await this._data.Obra.Update(result) > 0;
        }

        public async Task<bool> ObraPorCitadaAsync(string id)
        {
            var result = await this._data.Obra.GetById(id);
            if (result == null) return false;

            result.IdObraEstado = 1;

            return await this._data.Obra.Update(result) > 0;
        }

        public async Task<TObra> ObtenerAsync(string id)
        {
            return await this._data.Obra.GetById(id);
        }
    }
}
