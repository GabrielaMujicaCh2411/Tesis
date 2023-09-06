using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.TipoPartida;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class TipoPartidaService : BaseService, ITipoPartidaService
    {
        public TipoPartidaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TTipoPartida entidad)
        {
            var entidadActual = await this._data.TipoPartida.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Descripcion = entidad.Descripcion;
            entidadActual.Nombre = entidad.Nombre;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.TipoPartida.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TTipoPartida entidad)
        {
            var result = await this._data.TipoPartida.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id, int idUsuario)
        {
            var entidadActual = await this._data.TipoPartida.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = idUsuario;
            entidadActual.Borrado = true;

            var result = await this._data.TipoPartida.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TTipoPartida>> ListarAsync(TipoPartidaFilter model)
        {
            var predicates = new List<Expression<Func<TTipoPartida, bool>>>();

            if (!string.IsNullOrEmpty(model.Nombre))
            {
                predicates.Add(x => x.Nombre.ToUpper().Equals(model.Nombre.ToUpper()));
            }

            predicates.Add(x => x.Borrado == false);

            return await this._data.TipoPartida.SelectPredicatesWithIncludes(predicates);
        }

        public async Task<TTipoPartida> ObtenerAsync(int id)
        {
            return await this._data.TipoPartida.GetById(id);
        }
    }
}
