using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Usuario;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<TUsuario>> ListarAsync(UsuarioFilter model);

        Task<TUsuario> AgregarAsync(TUsuario entidad);

        Task<TUsuario> ObtenerAsync(int id);

        Task<TUsuario> ObtenerPorDniAsync(int dni);

        Task<bool> ActualizarAsync(int id, TUsuario entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);

    }
}
