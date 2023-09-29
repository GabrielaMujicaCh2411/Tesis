using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ITrabajadorxCotizacionService
    {
        Task<bool> AgregarAsync(IEnumerable<TTrabajadorxCotizacion> entidades);

        Task<IEnumerable<TTrabajadorxCotizacion>> ObtenerPorIdCotizacionAsync(int idCotizacion);

        Task<bool> RestaurarTrabajadorAsync(int idCotizacion, int idUsuario);
    }
}
