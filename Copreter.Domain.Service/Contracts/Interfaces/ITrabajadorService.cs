using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Model.Trabajador;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ITrabajadorService
    {
        Task<IEnumerable<TTrabajador>> ListarAsync(TrabajadorFilter model);

        Task<bool> AgregarAsync(TTrabajador entidad);

        Task<TTrabajador> ObtenerAsync(int id);

        Task<bool> ActualizarAsync(int id, TTrabajador entidad);

        Task<bool> EliminarAsync(int id, int idUsuario);

        Task<int> CountAsync();

        Task<bool> ActualizarEstadoAsync(IEnumerable<TTrabajador> lista, ETrabajadorEstado estado, int idUsuario);
    }
}
