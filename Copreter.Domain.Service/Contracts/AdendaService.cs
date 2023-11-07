using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class AdendaService : BaseService, IAdendaService
    {
        public AdendaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(TAdenda entidad)
        {
            var result = await this._data.Adenda.Add(entidad);
            return result == 1;
        }

        public async Task<TAdenda> ObtenerAsync(int id)
        {
            return await this._data.Adenda.GetById(id);
        }

        public async Task<TAdenda> ObtenerPorIdPedidoAsync(int idPedido)
        {
            return await this._data.Adenda.FirstOrDefault(x => x.IdPedido == idPedido);
        }
    }
}
