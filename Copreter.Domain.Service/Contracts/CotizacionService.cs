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

        public async Task<bool> AgregarAsync(TCotizacion entidad)
        {
            var result = await this._data.Cotizacion.Add(entidad);
            return result == 1;
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
            return await this._data.Cotizacion.GetById(id);
        }
    }
}
