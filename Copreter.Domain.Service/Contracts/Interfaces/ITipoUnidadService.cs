using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ITipoUnidadService
    {
        Task<IEnumerable<TTipoUnidad>> ListarAsync();
    }
}
