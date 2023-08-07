using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface IUsuarioService
    {
        Task<IEnumerable<TUsuario>> ListarAsync();

        Task<TUsuario> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TUsuario entidad);

        Task<bool> EliminarAsync(int id);
    }
}
