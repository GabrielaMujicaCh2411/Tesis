﻿using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class PartidaService : BaseService, IPartidaService
    {
        public PartidaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(string id, TPartida entidad)
        {
            var entidadActual = await this._data.Partida.GetById(id);
            if (entidadActual == null) return false;

            var result = await this._data.Partida.Update(entidad);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TPartida entidad)
        {
            var result = await this._data.Partida.Add(entidad);
            return result == 1;
        }

        public async Task<IEnumerable<TPartida>> ListarAsync()
        {
            return await this._data.Partida.GetAll();
        }

        public async Task<IEnumerable<TTipoPartida>> ListarTipoPartidaAsync()
        {
            return await this._data.TipoPartida.GetAll();
        }

        public async Task<TPartida> ObtenerAsync(string id)
        {
            return await this._data.Partida.GetById(id);
        }
    }
}
