using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IClienteService
    {
        Task<bool> AgregarAsync(TCliente entidad);

        Task<TCliente> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TCliente entidad);

        Task<bool> EliminarAsync(int id);
    }
}
