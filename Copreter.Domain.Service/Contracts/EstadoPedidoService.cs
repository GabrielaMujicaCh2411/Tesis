using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class EstadoPedidoService : BaseService, IEstadoPedidoService
    {
        public EstadoPedidoService(ICopreterData data) : base(data)
        {
        }

        public async Task<IEnumerable<TEstadoPedido>> ListarAsync()
        {
            return await this._data.EstadoPedido.SelectIncludes(x => x.Borrado == false);
        }
    }
}
