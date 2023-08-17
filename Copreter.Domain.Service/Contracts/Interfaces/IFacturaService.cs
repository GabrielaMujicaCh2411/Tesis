using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IFacturaService
    {
        Task<bool> AgregarAsync(TFactura entidad);
    }
}
