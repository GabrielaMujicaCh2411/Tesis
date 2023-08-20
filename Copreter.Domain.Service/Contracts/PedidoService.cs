using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class PedidoService : BaseService, IPedidoService
    {
        public PedidoService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TPedido entidad)
        {
            var entidadActual = await this._data.Pedido.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Pedido.Update(entidad);
            return result > 0;
        }

        public async Task<bool> ActualizarEstadoAsync(int id, int estado)
        {
            var entidadActual = await this._data.Pedido.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdEstadoPedido = estado;

            var result = await this._data.Pedido.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TPedido entidad)
        {
            var result = await this._data.Pedido.Add(entidad);
            return result > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Pedido.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Borrado = true;

            var result = await this._data.Pedido.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TPedido>> ListarAsync()
        {
            return await this._data.Pedido.SelectIncludes(x => x.Borrado == false);
        }

        public async Task<TPedido> ObtenerAsync(int id)
        {
            return await this._data.Pedido.GetById(id);
        }
    }
}
