using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Usuario;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Copreter.Domain.Service.Contracts
{
    internal class UsuarioService : BaseService, IUsuarioService
    {
        public UsuarioService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TUsuario>> ListarAsync(UsuarioFilter model)
        {
            var predicates = new List<Expression<Func<TUsuario, bool>>>();

            if (!string.IsNullOrEmpty(model.Apellido))
            {
                predicates.Add(x => x.Apellido.ToUpper().Equals(model.Apellido.ToUpper()));
            }

            if (!string.IsNullOrEmpty(model.Dni))
            {
                predicates.Add(x => x.Dni.Equals(model.Dni));
            }

            predicates.Add(x => x.Borrado == false);

            return await this._data.Usuario.SelectPredicatesWithIncludes(predicates);
        }

        public async Task<bool> ActualizarAsync(int id, TUsuario entidad)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Nombre = entidad.Nombre;
            entidadActual.Apellido = entidad.Apellido;
            entidadActual.Celular = entidad.Celular;
            entidadActual.Direccion = entidad.Direccion;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Usuario.Update(entidadActual);
            return result == 1;
        }

        public async Task<TUsuario> AgregarAsync(TUsuario entidad)
        {
            var result = await this._data.Usuario.AddAndReturn(entidad);
            return result != null ? result : null;
        }

        public async Task<bool> EliminarAsync(int id, int idUsuario)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = idUsuario;
            entidadActual.Borrado = true;

            var result = await this._data.Usuario.Update(entidadActual);
            return result == 1;
        }

        public async Task<TUsuario> ObtenerAsync(int id)
        {
            return await this._data.Usuario.GetById(id);
        }

        public async Task<TUsuario> ObtenerPorDniAsync(int dni)
        {
            return await this._data.Usuario.FirstOrDefault(x => x.Dni == dni);
        }
    }
}
