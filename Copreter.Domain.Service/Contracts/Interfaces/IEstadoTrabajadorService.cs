using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IEstadoTrabajadorService
    {
        Task<IEnumerable<TEstadoTrabajador>> ListarAsync();
    }
}
