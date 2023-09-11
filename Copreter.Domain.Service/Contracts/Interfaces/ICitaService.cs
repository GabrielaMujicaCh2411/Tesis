using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cita;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ICitaService
    {
        Task<IEnumerable<TCita>> ListarAsync(CitaFilter model);

        Task<TCita> ObtenerAsync(int id);

        Task<bool> AgregarAsync(TCita entidad);
    }
}
