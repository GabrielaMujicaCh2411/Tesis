using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Incidencia;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class IncidenciaService : BaseService, IIncidenciaService
    {
        public IncidenciaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TIncidencia entidad)
        {
            var entidadActual = await this._data.Incidencia.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Fecha = entidad.Fecha;
            entidadActual.Incidencia = entidad.Incidencia;
            entidadActual.HorasTrabajadas = entidad.HorasTrabajadas;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Incidencia.Update(entidadActual);
            return result == 1;
        }

        public async Task<bool> AgregarAsync(TIncidencia entidad)
        {
            var result = await this._data.Incidencia.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id, int idUsuario)
        {
            var entidadActual = await this._data.Incidencia.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = idUsuario;
            entidadActual.Borrado = true;

            var result = await this._data.Incidencia.Update(entidadActual);
            return result == 1;
        }

        public async Task<IEnumerable<TIncidencia>> ListarAsync(IncidenciaFilter model)
        {
            var predicates = new List<Expression<Func<TIncidencia, bool>>>();
  
            predicates.Add(x => x.Borrado == false);

            return await this._data.Incidencia.SelectPredicatesWithIncludes(predicates, x => x.IdPedidoNavigation);
        }

        public async Task<TIncidencia> ObtenerAsync(int id)
        {
            return await this._data.Incidencia.FirstOrDefault(x => x.Id == id, x => x.IdPedidoNavigation);
        }
    }
}
