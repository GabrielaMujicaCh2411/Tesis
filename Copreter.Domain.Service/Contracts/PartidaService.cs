using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class PartidaService : BaseService, IPartidaService
    {
        public PartidaService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TPartida entidad)
        {
            var entidadActual = await this._data.Partida.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.Nombre = entidad.Nombre;
            entidadActual.IdTipoPartida = entidad.IdTipoPartida;
            entidadActual.PrecioUnidad = entidad.PrecioUnidad;

            entidadActual.IdUsuarioModificacion = entidad.IdUsuarioModificacion;
            entidadActual.FechaModificacion = DateTime.Now;

            var result = await this._data.Partida.Update(entidadActual);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TPartida entidad)
        {
            var result = await this._data.Partida.Add(entidad);
            return result == 1;
        }

        public async Task<IEnumerable<TPartida>> ListarAsync()
        {
            return await this._data.Partida.SelectIncludes(x => x.Borrado == false, x => x.IdTipoPartidaNavigation);
        }

        public async Task<TPartida> ObtenerAsync(int id)
        {
            return await this._data.Partida.GetById(id);
        }

        public async Task<bool> EliminarAsync(int id, int idUsuario)
        {
            var entidadActual = await this._data.Partida.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = idUsuario;
            entidadActual.Borrado = true;

            var result = await this._data.Partida.Update(entidadActual);
            return result == 1;
        }
    }
}
