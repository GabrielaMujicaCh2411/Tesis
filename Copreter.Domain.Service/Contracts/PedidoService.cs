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

            entidadActual.IdEstadoPedido = entidad.IdEstadoPedido;
            entidadActual.IdTrabajador = entidad.IdTrabajador;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Pedido.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> ActualizarEstadoAsync(int id, int estado, int idUsuarioModificacion)
        {
            var entidadActual = await this._data.Pedido.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdEstadoPedido = estado;

            entidadActual.IdUsuarioModificacion = idUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Pedido.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TPedido entidad, TPedidoSolicitud entidadSolicitud)
        {
            var result = await this._data.Pedido.AddAndReturn(entidad);

            if (result != null)
            {
                entidadSolicitud.IdPedido = result.Id;
                entidadSolicitud.FechaDevolucion = entidad.FechaInicio.AddDays(entidadSolicitud.CantidadDias);

                var resultDetail = await this._data.PedidoSolicitud.Add(entidadSolicitud);
                return resultDetail == 1;
            }

            return result != null && result.Id > 0;
        }

        public async Task<int> CountAsync(int estado)
        {
            var predicates = new List<Expression<Func<TPedido, bool>>>();

            var currentDate = DateTime.Now;

            switch (estado)
            {
                case 7:
                    {
                        predicates.Add(x => x.FechaRegistro >= new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 0, 0, 0) && x.FechaRegistro >= new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 00));
                    }
                    break;
            }

            predicates.Add(x => x.IdEstadoPedido == estado);
            predicates.Add(x => x.Borrado == false);

            var result = await this._data.Pedido.SelectPredicatesWithIncludes(predicates, x => x.IdEstadoPedidoNavigation);
            return result != null ? result.Count() : 0;
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

            if (model.IdUsuario.HasValue && model.IdUsuario != -1)
            {
                predicates.Add(x => x.IdUsuario == model.IdUsuario);
            }
            if (model.IdEstado.HasValue && model.IdEstado != -1)
            {
                predicates.Add(x => x.IdEstadoPedido == model.IdEstado);
            }
            predicates.Add(x => x.Borrado == false);

            return await this._data.Pedido.SelectPredicatesWithIncludes(predicates, x => x.IdEstadoPedidoNavigation,
                x => x.IdUnidadNavigation,
                x => x.IdUnidadNavigation.IdTipoUnidadNavigation);
        }

        public async Task<TPedido> ObtenerAsync(int id)
        {
            return await this._data.Pedido.FirstOrDefault(x => x.Id == id, x => x.IdUnidadNavigation);
        }

        public async Task<IEnumerable<TPedidoSolicitud>> ObtenerPedidoSolicitudAsync(int idPedido)
        {
            return await this._data.PedidoSolicitud.SelectIncludes(x => x.IdPedido == idPedido);
        }

        public async Task<IEnumerable<TPedido>> PendienteDevolverAsync()
        {
            var predicates = new List<Expression<Func<TPedido, bool>>>();

            //predicates.Add(x => x.FechaEntrega.Value.AddDays(x.CantidadDias) > DateTime.Now);
            predicates.Add(x => x.Borrado == false);

            return await this._data.Pedido.SelectPredicatesWithIncludes(predicates, x => x.IdEstadoPedidoNavigation,
            x => x.IdUnidadNavigation,
            x => x.IdUnidadNavigation.IdTipoUnidadNavigation);
        }

        public async Task<bool> AgregarMasDiasAsync(int idPedido, TPedidoSolicitud entidadSolicitud)
        {
            var result = await this.ObtenerAsync(idPedido);

            if (result != null)
            {
                var pedidos = await this._data.PedidoSolicitud.SelectIncludes(x => x.IdPedido == idPedido);

                var pedidoActual = pedidos.OrderByDescending(x => x.FechaDevolucion).ToList();

                entidadSolicitud.Id = 0;
                entidadSolicitud.IdPedido = result.Id;
                entidadSolicitud.FechaDevolucion = pedidoActual != null && pedidoActual.Any() ? pedidoActual.FirstOrDefault().FechaDevolucion.Value.AddDays(entidadSolicitud.CantidadDias) : DateTime.Now;

                var resultDetail = await this._data.PedidoSolicitud.Add(entidadSolicitud);
                return resultDetail == 1;
            }

            return result != null && result.Id > 0;
        }
    }
}
