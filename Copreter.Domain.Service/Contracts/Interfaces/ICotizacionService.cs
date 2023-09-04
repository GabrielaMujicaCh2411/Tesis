using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cotizacion;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ICotizacionService
    {
        Task<IEnumerable<TCotizacion>> ListarAsync(CotizacionFilter model);

        Task<bool> AgregarAsync(TCotizacion entidad);

        Task<TCotizacion> ObtenerAsync(int id);
    }
}
