using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ICotizacionxUnidadService
    {
        Task<bool> AgregarAsync(IEnumerable<TCotizacionxUnidad> entidades);
    }
}
