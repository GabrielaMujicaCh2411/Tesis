using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<TCliente>> ListarAsync();

        Task<bool> AgregarAsync(TCliente entidad);

        Task<TCliente> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TCliente entidad);

        Task<bool> EliminarAsync(int id);
    }
}
