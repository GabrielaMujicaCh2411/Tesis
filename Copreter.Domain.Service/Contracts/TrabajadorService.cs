using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Trabajador;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class TrabajadorService : BaseService, ITrabajadorService
    {
        public TrabajadorService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TTrabajador entidad)
        {
            var entidadActual = await this._data.Trabajador.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Nombre = entidad.Nombre;
            entidadActual.Apellido = entidad.Apellido;
            entidadActual.Celular = entidad.Celular;
            entidadActual.IdTipoTrabajador = entidad.IdTipoTrabajador;
            entidadActual.IdEstadoTrabajador = entidad.IdEstadoTrabajador;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Trabajador.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TTrabajador entidad)
        {
            var result = await this._data.Trabajador.Add(entidad);
            return result == 1;
        }

        public async Task<int> CountAsync()
        {
            return await this._data.Trabajador.CountIncludes(x => x.Borrado == false);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Trabajador.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Trabajador.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TTrabajador>> ListarAsync(TrabajadorFilter model)
        {
            var predicates = new List<Expression<Func<TTrabajador, bool>>>();

            if (model.IdEstado.HasValue && model.IdEstado != 0)
            {
                predicates.Add(x => x.IdEstadoTrabajador == model.IdEstado);
            }

            if (model.IdTipo.HasValue && model.IdTipo != 0)
            {
                predicates.Add(x => x.IdTipoTrabajador == model.IdTipo);
            }

            predicates.Add(x => x.Borrado == false);


            return await this._data.Trabajador.SelectPredicatesWithIncludes(predicates, x => x.IdTipoTrabajadorNavigation, x => x.IdEstadoTrabajadorNavigation);
        }

        public async Task<TTrabajador> ObtenerAsync(int id)
        {
            return await this._data.Trabajador.GetById(id);
        }
    }
}
