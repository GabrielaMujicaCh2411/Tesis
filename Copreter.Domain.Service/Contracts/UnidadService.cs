using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Model.Unidad;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class UnidadService : BaseService, IUnidadService
    {


        public UnidadService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TUnidad entidad)
        {
            var entidadActual = await this._data.Unidad.GetById(id);
            if (entidadActual == null) return false;

            entidad.Id = entidadActual.Id;
            entidad.IdUsuarioRegistro = entidadActual.IdUsuarioRegistro;
            entidad.FechaRegistro = entidadActual.FechaRegistro;

            entidad.FechaModificacion = DateTime.Now;

            var result = await this._data.Unidad.Update(entidad);
            return result > 0;
        }

        public async Task<bool> ActualizarCantidadAsync(int id, int cantidad, bool aumentar, int idUsuario)
        {
            var entidadActual = await this._data.Unidad.GetById(id);
            if (entidadActual == null) return false;

            int cantidadCalculada;
            if (aumentar)
            {
                cantidadCalculada = entidadActual.CantidadDisponible + cantidad;
            }
            else
            {
                cantidadCalculada = entidadActual.CantidadDisponible - cantidad;
            }

            entidadActual.CantidadDisponible = cantidadCalculada;
            entidadActual.IdEstadoUnidad = entidadActual.CantidadDisponible > 0 ? (int)EUnidadEstado.Disponible : (int)EUnidadEstado.NoDisponible;
            entidadActual.IdUsuarioModificacion = idUsuario;

            var result = await this._data.Unidad.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> ActualizarEstadoAsync(IEnumerable<TUnidad> lista, EUnidadEstado estado, int idUsuario)
        {
            foreach (var item in lista)
            {
                var entidadActual = await this._data.Unidad.GetById(item.Id);
                if (entidadActual == null) continue;

                var disponible = entidadActual.CantidadDisponible - item.Cantidad;
                entidadActual.CantidadDisponible = disponible > 0 ? disponible : 0;

                entidadActual.IdEstadoUnidad = disponible > 0 ? (int)EUnidadEstado.Disponible : (int)EUnidadEstado.NoDisponible;

                entidadActual.IdUsuarioModificacion = idUsuario;
                entidadActual.FechaModificacion = DateTime.Now;

                await this._data.Unidad.Update(entidadActual);
            }
            return true;
        }

        public async Task<bool> AgregarAsync(TUnidad entidad)
        {
            entidad.CantidadDisponible = entidad.Cantidad;

            var result = await this._data.Unidad.Add(entidad);
            return result == 1;
        }

        public async Task<int> CountAsync(int idEstado)
        {
            var result = await this._data.Unidad.SelectIncludes(x => x.Borrado == false && x.IdEstadoUnidad == idEstado);
            return result.Count();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Unidad.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Unidad.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TUnidad>> ListarAsync(UnidadFilter model)
        {
            var predicates = new List<Expression<Func<TUnidad, bool>>>();

            if (model.IdEstado.HasValue && model.IdEstado != 0)
            {
                predicates.Add(x => x.IdEstadoUnidad == model.IdEstado);
            }

            if (model.IdTipo.HasValue && model.IdTipo != 0)
            {
                predicates.Add(x => x.IdTipoUnidad == model.IdTipo);
            }

            predicates.Add(x => x.Borrado == false);

            return await this._data.Unidad.SelectPredicatesWithIncludes(predicates, x => x.IdTipoUnidadNavigation, x => x.IdEstadoUnidadNavigation);
        }

        public async Task<IEnumerable<TUnidad>> ListarCatalagoAsync(int tipoUnidad)
        {
            var predicates = new List<Expression<Func<TUnidad, bool>>>();

            if (tipoUnidad != 0)
            {
                predicates.Add(x => x.IdTipoUnidad == tipoUnidad);
            }

            predicates.Add(x => x.Borrado == false && x.IdEstadoUnidad == 1);

            return await this._data.Unidad.SelectPredicatesWithIncludes(predicates);
        }

        public async Task<TUnidad> ObtenerAsync(int id)
        {
            return await this._data.Unidad.FirstOrDefault(x => x.Id == id, x => x.IdTipoUnidadNavigation, x => x.IdEstadoUnidadNavigation);
        }
    }
}
