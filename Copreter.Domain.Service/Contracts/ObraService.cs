using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class ObraService : BaseService, IObraService
    {
        public ObraService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TObra>> ListarAsync(int? id)
        {
            var predicates = new List<Expression<Func<TObra, bool>>>();
            if (id != null)
            {
                predicates.Add(x => x.IdUsuario == id);
            }
            predicates.Add(x => x.Borrado == false);

            return await this._data.Obra.SelectPredicatesWithIncludes(predicates, x=> x.IdEstadoObraNavigation);
        }

        public async Task<IEnumerable<TObra>> ListarPorEstadoAsync(List<int> estados)
        {
            return await this._data.Obra.SelectIncludes(x => estados.Contains(x.IdEstadoObra));
        }

        public async Task<bool> AgregarAsync(TObra entidad)
        {
            entidad.IdEstadoObra = 1;
            var result = await this._data.Obra.Add(entidad);
            return result == 1;
        }

        public async Task<bool> ActualizarEstado(int id, EObraEstado estado)
        {
            var result = await this._data.Obra.GetById(id);
            if (result == null) return false;

            result.IdEstadoObra = (int)estado;

            return await this._data.Obra.Update(result) > 0;
        }

        public async Task<TObra> ObtenerAsync(int id)
        {
            return await this._data.Obra.GetById(id);
        }
    }
}
