using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface IPagoService
    {
        Task<bool> AgregarAsync(TPago entidad);
    }
}
