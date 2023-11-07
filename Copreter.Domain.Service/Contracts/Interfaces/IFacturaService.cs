using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IFacturaService
    {
        Task<bool> AgregarAsync(TFactura entidad);
        Task<TFactura> ObtenerAsync(int id);

        Task<TFactura> ObtenerPorIdCotizacionAsync(int idCotizacion);
    }
}
