using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<TUsuario>> ListarAsync();

        Task<TUsuario> ObtenerAsync(string id);

        Task<bool> CrearAsync(TUsuario entidad);

        Task<bool> ActualizarAsync(string id, TUsuario entidad);

        Task<bool> EliminarAsync(string id);
    }
}
