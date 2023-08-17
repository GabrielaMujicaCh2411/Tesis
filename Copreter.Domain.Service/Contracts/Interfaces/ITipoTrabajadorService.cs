using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ITipoTrabajadorService
    {
        Task<IEnumerable<TTipoTrabajador>> ListarAsync();
    }
}
