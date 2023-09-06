using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IObraPartidaService
    {
        Task<bool> AgregarAsync(IEnumerable<TObraxPartida> entidades);

        Task<IEnumerable<TObraxPartida>> ListarPorIdObraAsync(int idObra);
    }
}
