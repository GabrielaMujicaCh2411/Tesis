using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cotizacion;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class CotizacionService : BaseService, ICotizacionService
    {
        public CotizacionService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarEstadoAsync(int id, int estado, int idUsuarioModificacion)
        {
            var result = await this._data.Cotizacion.GetById(id);
            if (result == null) return false;

            result.IdEstadoCotizacion = estado;

            result.IdUsuarioModificacion = idUsuarioModificacion;
            result.FechaModificacion = DateTime.Now;

            return await this._data.Cotizacion.Update(result) > 0;
        }

        public async Task<bool> ActualizarEstadoPorObraAsync(int idObra, int estado, int idUsuarioModificacion)
        {
            var result = await this._data.Cotizacion.FirstOrDefault(x=> x.IdObra == idObra);
            if (result == null) return false;

            result.IdEstadoCotizacion = estado;

            result.IdUsuarioModificacion = idUsuarioModificacion;
            result.FechaModificacion = DateTime.Now;

            return await this._data.Cotizacion.Update(result) > 0;
        }

        public async Task<bool> AgregarAsync(TCotizacion entidad)
        {
            entidad.Fecha = DateTime.Now;
            entidad.IdEstadoCotizacion = 1;
            entidad.Saldo = entidad.Total;
            var result = await this._data.Cotizacion.Add(entidad);
            return result == 1;
        }

        public async Task<int> CountAsync(int idEstado)
        {
            return await this._data.Cotizacion.CountIncludes(x => x.Borrado == false && x.IdEstadoCotizacion == idEstado);
        }

        public async Task<IEnumerable<TCotizacion>> ListarAsync(CotizacionFilter model)
        {
            var predicates = new List<Expression<Func<TCotizacion, bool>>>();

            if (model.IdEstado != null && model.IdEstado != 0)
            {

                predicates.Add(x => x.IdEstadoCotizacion == model.IdEstado);
            }

            predicates.Add(x => x.Borrado == false);

            return await this._data.Cotizacion.SelectPredicatesWithIncludes(predicates, x => x.IdEstadoCotizacionNavigation);
        }

        public async Task<TCotizacion> ObtenerAsync(int id)
        {
            return await this._data.Cotizacion.FirstOrDefault(x=> x.Id == id, x=> x.IdObraNavigation);
        }

        public async Task<TCotizacion> ObtenerPorIdObraAsync(int idObra)
        {
            return await this._data.Cotizacion.FirstOrDefault(x => x.IdObra == idObra, x => x.IdObraNavigation);
        }
    }
}
