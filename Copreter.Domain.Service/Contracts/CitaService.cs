﻿using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class CitaService : BaseService, ICitaService
    {
        public CitaService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TCita>> ListarAsync()
        {
            return await this._data.Cita.SelectIncludes
                (x => x.Borrado == false &&
                x.IdObraNavigation != null && x.IdObraNavigation.Id == 1,
                x => x.IdObraNavigation);
        }

        public async Task<bool> AgregarAsync(TCita entidad)
        {
            var result = await this._data.Cita.Add(entidad);
            return result == 1;
        }

        public async Task<TCita> ObtenerPorIdAsync(int id)
        {
            return await this._data.Cita.GetById(id);
        }
    }
}
