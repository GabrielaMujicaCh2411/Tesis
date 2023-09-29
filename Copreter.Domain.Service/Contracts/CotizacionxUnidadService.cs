using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class CotizacionxUnidadService : BaseService, ICotizacionxUnidadService
    {
        private readonly IUnidadService _unidadService;

        public CotizacionxUnidadService(ICopreterData data, IUnidadService unidadService) : base(data)
        {
            this._unidadService = unidadService;
        }

        public async Task<bool> AgregarAsync(IEnumerable<TCotizacionxUnidad> entidades)
        {
            foreach (var entidade in entidades)
            {
                entidade.Id = 0;
            }

            await this._data.CotizacionXUnidad.AddRange(entidades);
            return true;
        }

        public async Task<IEnumerable<TCotizacionxUnidad>> ObtenerPorIdCotizacionAsync(int idCotizacion)
        {
            return await this._data.CotizacionXUnidad.SelectIncludes(x => x.IdCotizacion == idCotizacion);
        }

        public async Task<bool> RestaurarUnidadAsync(int idCotizacion, int idUsuario)
        {
            var unidadXCoti = await this.ObtenerPorIdCotizacionAsync(idCotizacion);

            if(unidadXCoti != null && unidadXCoti.Any())
            {
                foreach (var uc in unidadXCoti)
                {
                    await this._unidadService.ActualizarCantidadAsync(uc.IdUnidad, uc.IdUnidad, true, idUsuario);

                }
            }
            return true;
        }
    }
}
