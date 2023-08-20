using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<TUsuario>> ListarAsync();

        Task<TUsuario> ObtenerAsync(int id);

        Task<bool> CrearAsync(TUsuario entidad);

        Task<bool> ActualizarAsync(int id, TUsuario entidad);

        Task<bool> EliminarAsync(int id);
    }
}
