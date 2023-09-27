using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class TrabajadorxCotizacionService : BaseService, ITrabajadorxCotizacionService
    {
        public TrabajadorxCotizacionService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> AgregarAsync(IEnumerable<TTrabajadorxCotizacion> entidades)
        {
            foreach (var entidade in entidades)
            {
                entidade.Id = 0;
            }

            await this._data.TrabajadorxCotizacion.AddRange(entidades);
            return true;
        }
    }
}
