using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IAccesoService
    {
        Task<IEnumerable<TAcceso>> ListarAsync();

        Task<TAcceso> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TAcceso entidad);

        Task<bool> ActualizarAsync(int id, TAcceso entidad);

        Task<bool> EliminarAsync(int id);
    }
}
