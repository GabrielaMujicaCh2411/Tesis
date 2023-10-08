using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Obra;
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

        public async Task<IEnumerable<TObra>> ListarAsync(ObraFilter model)
        {
            var predicates = new List<Expression<Func<TObra, bool>>>();
            if (model.IdUsuario != null && model.IdUsuario != 0)
            {
                predicates.Add(x => x.IdUsuario == model.IdUsuario);
            }
            if (model.IdEstado != null && model.IdEstado != 0)
            {
                if (model.IdEstado == 1)
                {
                    predicates.Add(x => x.IdEstadoObra == 1 || x.IdEstadoObra == 3);
                }
                else
                {
                    predicates.Add(x => x.IdEstadoObra == model.IdEstado);
                }
            }

            predicates.Add(x => x.Borrado == false);

            return await this._data.Obra.SelectPredicatesWithIncludes(predicates, x => x.IdEstadoObraNavigation, x=> x.IdUsuarioNavigation);
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

        public async Task<bool> ActualizarEstadoAsync(int id, int estado, int idUsuarioModificacion)
        {
            var result = await this._data.Obra.GetById(id);
            if (result == null) return false;

            result.IdEstadoObra = estado;

            result.IdUsuarioModificacion = idUsuarioModificacion;
            result.FechaModificacion = DateTime.Now;

            return await this._data.Obra.Update(result) > 0;
        }

        public async Task<TObra> ObtenerAsync(int id)
        {
            return await this._data.Obra.FirstOrDefault(x => x.Id == id, x => x.IdEstadoObraNavigation);
        }

        public async Task<int> CountAsync(int idEstado)
        {
            return await this._data.Obra.CountIncludes(x => x.Borrado == false && x.IdEstadoObra == idEstado);
        }
    }
}
