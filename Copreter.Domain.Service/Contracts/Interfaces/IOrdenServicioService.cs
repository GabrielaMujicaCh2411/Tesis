using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IOrdenServicioService
    {
        Task<bool> AgregarAsync(TOrdenServicio entidad);

        Task<TOrdenServicio> ObtenerAsync(int id);

        Task<TOrdenServicio> ObtenerPorIdCotizacionAsync(int idCotizacion);
    }
}
