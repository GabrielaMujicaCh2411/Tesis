using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ICotizacionxUnidadService
    {
        Task<bool> AgregarAsync(IEnumerable<TCotizacionxUnidad> entidades);
        Task<IEnumerable<TCotizacionxUnidad>> ObtenerPorIdCotizacionAsync(int idCotizacion);
        Task<bool> RestaurarUnidadAsync(int idCotizacion, int idUsuario);
    }
}
