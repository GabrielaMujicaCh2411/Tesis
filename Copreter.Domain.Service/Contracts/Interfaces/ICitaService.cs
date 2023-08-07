using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    internal interface ICitaService
    {
        Task<IEnumerable<TCita>> ListarAsync();

        Task<TCita> ObtenerPorIdAsync(string id);

        Task<bool> AgregarAsync(TCita entidad);
    }
}
