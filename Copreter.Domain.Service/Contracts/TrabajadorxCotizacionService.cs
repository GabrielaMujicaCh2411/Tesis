using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class TrabajadorxCotizacionService : BaseService, ITrabajadorxCotizacionService
    {
        private readonly ITrabajadorService _trabajadorService;

        public TrabajadorxCotizacionService(ICopreterData data, ITrabajadorService trabajadorService) : base(data)
        {
            this._trabajadorService = trabajadorService;
        }

        public async Task<bool> AgregarAsync(IEnumerable<TTrabajadorxCotizacion> entidades)
        {
            foreach (var entidade in entidades)
            {
                entidade.Id = 0;
            }

            await this._data.TrabajadorxCotizacion.AddRange(entidades);
            return true;
        }

        public async Task<IEnumerable<TTrabajadorxCotizacion>> ObtenerPorIdCotizacionAsync(int idCotizacion)
        {
            return await this._data.TrabajadorxCotizacion.SelectIncludes(x => x.IdCotizacion == idCotizacion);
        }

        public async Task<bool> RestaurarTrabajadorAsync(int idCotizacion, int idUsuario)
        {
            var trabajadorXCoti = await this.ObtenerPorIdCotizacionAsync(idCotizacion);

            if(trabajadorXCoti != null && trabajadorXCoti.Any())
            {
                await this._trabajadorService.ActualizarEstadoAsync(trabajadorXCoti.Select(x=> x.IdTrabajador).ToList(), ETrabajadorEstado.Disponible, idUsuario);
            }
            return true;
        }
    }
}
