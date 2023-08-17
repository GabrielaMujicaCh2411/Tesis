using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ICotizacionService
    {
        Task<IEnumerable<TCotizacion>> ListarAsync();

        Task<bool> AgregarAsync(TCotizacion entidad);
    }
}
