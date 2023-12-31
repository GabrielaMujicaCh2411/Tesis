﻿using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class ObraPartidaService : BaseService, IObraPartidaService
    {
        public ObraPartidaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(IEnumerable<TObraxPartida> entidades)
        {
            await this._data.ObraPartida.AddRange(entidades);
            return true;
        }

        public async Task<IEnumerable<TObraxPartida>> ListarPorIdObraAsync(int idObra)
        {
            return await this._data.ObraPartida.SelectIncludes(x=> x.IdObra == idObra, x=> x.IdObraNavigation, x=> x.IdPartidaNavigation);
        }
    }
}
