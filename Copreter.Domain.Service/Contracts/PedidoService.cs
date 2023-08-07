using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copreter.Domain.Service.Contracts
{
    internal class PedidoService : BaseService, IPedidoService
    {
        public PedidoService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(string id, TPedido entidad)
        {
            var entidadActual = await this._data.Pedido.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Pedido.Update(entidad);
            return result > 0;
        }

        public async Task<bool> ActualizarEstadoAsync(string id, int estado)
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

        public async Task<bool> EliminarAsync(string id)
        {
            var entidadActual = await this._data.Pedido.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Pedido.DeleteAndReturn(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TPedido>> ListarAsync()
        {
            return await this._data.Pedido.GetAll();
        }

        public async Task<TPedido> ObtenerAsync(string id)
        {
            return await this._data.Pedido.GetById(id);
        }
    }
}
