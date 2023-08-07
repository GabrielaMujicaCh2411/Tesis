using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface ITrabajadorService
    {
        Task<IEnumerable<TTrabajador>> ListarAsync();

        Task<TTrabajador> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TTrabajador entidad);

        Task<bool> EliminarAsync(int id);
    }
}
