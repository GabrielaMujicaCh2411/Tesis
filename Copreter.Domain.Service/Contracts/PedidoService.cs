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
    internal class PedidoService : BaseService, IPedidoService
    {
        public PedidoService(ICopreterData data) : base(data)
        {
        }

        public Task<bool> ActualizarAsync(string id, TPedido entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarEstadoAsync(string id, int estado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TPedido>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TPedido> ObtenerAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
