using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface IFacturaService
    {
        Task<bool> AgregarAsync(TFactura entidad);
    }
}
