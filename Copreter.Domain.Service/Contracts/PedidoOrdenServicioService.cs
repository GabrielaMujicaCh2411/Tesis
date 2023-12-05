using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class PedidoOrdenServicioService : BaseService, IPedidoOrdenServicioService
    {
        public PedidoOrdenServicioService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(TPedidoOrdenServicio entidad)
        {
            var result = await this._data.PedidoOrdenServicio.Add(entidad);
            return result == 1;
        }

        public async Task<TPedidoOrdenServicio> ObtenerAsync(int id)
        {
            return await this._data.PedidoOrdenServicio.GetById(id);
        }

        public async Task<IEnumerable<TPedidoOrdenServicio>> ObtenerPorIdPedidoAsync(int IdPedido)
        {
            return await this._data.PedidoOrdenServicio.SelectIncludes(x => x.IdPedido == IdPedido);
        }

        public async Task<TPedidoOrdenServicio> ObtenerPorIdAsync(int id)
        {
            return await this._data.PedidoOrdenServicio.GetById(id);
        }
    }
}
