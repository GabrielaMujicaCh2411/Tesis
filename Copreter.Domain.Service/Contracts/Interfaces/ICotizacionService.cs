using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Model.Cotizacion;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface ICotizacionService
    {
        Task<IEnumerable<TCotizacion>> ListarAsync(CotizacionFilter model);

        Task<bool> AgregarAsync(TCotizacion entidad);

        Task<TCotizacion> ObtenerAsync(int id);

        Task<int> CountAsync(int idEstado);

        Task<TCotizacion> ObtenerPorIdObraAsync(int idObra);

        Task<bool> ActualizarEstadoPorObraAsync(int idObra, int estado, int idUsuarioModificacion);

        Task<bool> ActualizarEstadoAsync(int id, int estado, int idUsuarioModificacion);
    }
}
