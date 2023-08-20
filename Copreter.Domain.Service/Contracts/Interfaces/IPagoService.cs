using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IPagoService
    {
        Task<bool> AgregarAsync(TPago entidad);

        Task<TPago> ObtenerAsync(int id);
    }
}
