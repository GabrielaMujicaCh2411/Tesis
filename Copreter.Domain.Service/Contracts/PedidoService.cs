using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Pedido;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

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

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Pedido.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TPedido>> ListarAsync(PedidoFilter model)
        {
            var predicates = new List<Expression<Func<TPedido, bool>>>();

            if (model.IdUsuario != -1)
            {
                predicates.Add(x => x.IdUsuario == model.IdUsuario);
            }
            if (model.IdEstado != 0 && model.IdEstado != -1)
            {
                predicates.Add(x => x.IdEstadoPedido == model.IdEstado);
            }
            predicates.Add(x => x.Borrado == false);

            return await this._data.Pedido.SelectPredicatesWithIncludes(predicates, x=> x.IdEstadoPedidoNavigation);
        }

        public async Task<TPedido> ObtenerAsync(int id)
        {
            return await this._data.Pedido.GetById(id);
        }
    }
}
