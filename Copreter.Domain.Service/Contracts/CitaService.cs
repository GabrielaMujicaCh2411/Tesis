using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cita;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class CitaService : BaseService, ICitaService
    {
        public CitaService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TCita>> ListarAsync(CitaFilter model)
        {
            var predicates = new List<Expression<Func<TCita, bool>>>();

            if (model.IdEstado != null && model.IdEstado != 0)
            {
                predicates.Add(x => x.IdObraNavigation.IdEstadoObra == model.IdEstado);
            }

            predicates.Add(x => x.Borrado == false);

            return await this._data.Cita.SelectPredicatesWithIncludes(predicates, x => x.IdObraNavigation);
        }

        public async Task<bool> AgregarAsync(TCita entidad)
        {
            var result = await this._data.Cita.Add(entidad);
            return result == 1;
        }

        public async Task<TCita> ObtenerAsync(int id)
        {
            return await this._data.Cita.FirstOrDefault(x=> x.Id == id, x=> x.IdObraNavigation);
        }
    }
}
