﻿using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class UsuarioService : BaseService, IUsuarioService
    {
        public UsuarioService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TUsuario entidad)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            entidad.Id = entidadActual.Id;
            entidad.IdUsuarioRegistro = entidadActual.IdUsuarioRegistro;
            entidad.FechaRegistro = entidadActual.FechaRegistro;

            entidad.IdUsuarioModificacion = 2;
            entidad.FechaModificacion = DateTime.Now;

            var result = await this._data.Usuario.Update(entidad);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TUsuario entidad)
        {
            var result = await this._data.Usuario.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Usuario.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 2;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Usuario.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TUsuario>> ListarAsync()
        {
            return await this._data.Usuario.SelectIncludes(x => x.Borrado == false);
        }

        public async Task<TUsuario> ObtenerAsync(int id)
        {
            return await this._data.Usuario.GetById(id);
        }
    }
}
