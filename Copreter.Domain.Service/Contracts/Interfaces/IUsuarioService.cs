using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<TUsuario>> ListarAsync();

        Task<TUsuario> AgregarAsync(TUsuario entidad);

        Task<TUsuario> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TUsuario entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);
    }
}
