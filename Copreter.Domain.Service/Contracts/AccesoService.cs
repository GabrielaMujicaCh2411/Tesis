using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Acceso;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class AccesoService : BaseService, IAccesoService
    {
        public AccesoService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TAcceso entidad)
        {
            var entidadActual = await this._data.Acceso.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdRol = entidad.IdRol;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Acceso.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(int idUsuario, TAcceso entidad)
        {
            entidad.IdUsuario = idUsuario;
            var result = await this._data.Acceso.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Acceso.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 1;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Acceso.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TAcceso>> ListarAsync(AccesoFilter model)
        {
            var predicates = new List<Expression<Func<TAcceso, bool>>>();

            if (model.Dni.HasValue && model.Dni != 0)
            {
                predicates.Add(x => x.IdUsuarioNavigation.Dni.Equals(model.Dni));
            }

            if (!string.IsNullOrEmpty(model.Apellido))
            {
                predicates.Add(x => x.IdUsuarioNavigation.Apellido.ToUpper().Equals(model.Apellido.ToUpper()));
            }

            predicates.Add(x => x.Borrado == false);

            return await this._data.Acceso.SelectIncludes(x => x.Borrado == false, x => x.IdRolNavigation, x => x.IdUsuarioNavigation);
        }

        public async Task<TAcceso> ObtenerAsync(int id)
        {
            return await this._data.Acceso.FirstOrDefault(x=> x.Id == id, x=> x.IdUsuarioNavigation, x=> x.IdRolNavigation);
        }

        public async Task<int> CountAsync(int idRol)
        {
            return await this._data.Acceso.CountIncludes(x => x.Borrado == false && x.IdRol == idRol);
        }
    }
}
