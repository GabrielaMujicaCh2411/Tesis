using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Obra;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class ObraIncidenciaService : BaseService, IObraIncidenciaService
    {
        public ObraIncidenciaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TObraIncidencia entidad)
        {
            var entidadActual = await this._data.ObraIncidencia.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Fecha = entidad.Fecha;
            entidadActual.Incidencia = entidad.Incidencia;
            entidadActual.HorasTrabajadas = entidad.HorasTrabajadas;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.ObraIncidencia.Update(entidadActual);
            return result == 1;
        }

        public async Task<bool> AgregarAsync(TObraIncidencia entidad)
        {
            var result = await this._data.ObraIncidencia.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id, int idUsuario)
        {
            var entidadActual = await this._data.ObraIncidencia.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = idUsuario;
            entidadActual.Borrado = true;

            var result = await this._data.ObraIncidencia.Update(entidadActual);
            return result == 1;
        }

        public async Task<IEnumerable<TObraIncidencia>> ListarAsync(ObraIndicendiaFilter model)
        {
            var predicates = new List<Expression<Func<TObraIncidencia, bool>>>();

            predicates.Add(x => x.IdObra == model.IdObra);
            predicates.Add(x => x.Borrado == false);

            return await this._data.ObraIncidencia.SelectPredicatesWithIncludes(predicates, x => x.IdObraNavigation);

        }

        public async Task<TObraIncidencia> ObtenerAsync(int id)
        {
            return await this._data.ObraIncidencia.FirstOrDefault(x => x.Id == id, x => x.IdObraNavigation);
        }
    }
}
