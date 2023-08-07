using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface ICotizacionService
    {
        Task<IEnumerable<TCotizacion>> ListarAsync();

        Task<bool> AgregarAsync(TCotizacion entidad);
    }
}
