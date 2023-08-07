using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copreter.Domain.Service.Contracts
{
    internal class UsuarioService : BaseService, IUsuarioService
    {
        public UsuarioService(ICopreterData data) : base(data)
        {
        }

        public Task<bool> ActualizarAsync(int id, TUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TUsuario>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TUsuario> ObtenerAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
