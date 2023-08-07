using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface ITipoUnidadService
    {
        Task<IEnumerable<TTipoUnidad>> ListarAsync();
    }
}
