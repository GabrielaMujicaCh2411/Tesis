using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IConfiguracionService
    {
        Task<IEnumerable<TConfiguracion>> ListarAsync();

        Task<TConfiguracion> ObtenerAsync(int id);

        Task<TConfiguracion> ObtenerPorNombre(string value);

        Task<decimal> ObtenerValorDecimal(string value);

        Task<bool> AgregarAsync(TConfiguracion entidad);

        Task<bool> ActualizarAsync(int id, TConfiguracion entidad);

        Task<bool> EliminarAsync(int id);
    }
}
