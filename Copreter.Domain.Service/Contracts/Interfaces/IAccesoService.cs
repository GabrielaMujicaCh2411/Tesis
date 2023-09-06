using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Acceso;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IAccesoService
    {
        Task<IEnumerable<TAcceso>> ListarAsync(AccesoFilter model);

        Task<TAcceso> ObtenerAsync(int id);

        Task<bool> AgregarAsync(int idUsuario, TAcceso entidad);

        Task<bool> ActualizarAsync(int id, TAcceso entidad);

        Task<bool> EliminarAsync(int id);

        Task<int> CountAsync(int idRol);
    }
}
