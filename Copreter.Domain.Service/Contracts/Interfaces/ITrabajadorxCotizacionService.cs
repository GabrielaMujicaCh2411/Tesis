using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ITrabajadorxCotizacionService
    {
        Task<bool> AgregarAsync(IEnumerable<TTrabajadorxCotizacion> entidades);
    }
}
