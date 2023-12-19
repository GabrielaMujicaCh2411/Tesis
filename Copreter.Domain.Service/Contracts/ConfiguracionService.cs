using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    internal class ConfiguracionService : BaseService, IConfiguracionService
    {
        public ConfiguracionService(ICopreterData data) : base(data)
        {
        }

        public async Task<bool> ActualizarAsync(int id, TConfiguracion entidad)
        {
            var entidadActual = await this._data.Configuracion.GetById(id);
            if (entidadActual == null) return false;

            entidad.Id = entidadActual.Id;
            entidad.IdUsuarioRegistro = entidadActual.IdUsuarioRegistro;
            entidad.FechaRegistro = entidadActual.FechaRegistro;

            entidad.FechaModificacion = DateTime.Now;

            var result = await this._data.Configuracion.Update(entidad);
            return result > 0;
        }

        public async Task<bool> AgregarAsync(TConfiguracion entidad)
        {
            var result = await this._data.Configuracion.Add(entidad);
            return result == 1;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidadActual = await this._data.Configuracion.GetById(id);
            if (entidadActual == null) return false;

            entidadActual.IdUsuarioModificacion = 1;
            entidadActual.FechaModificacion = DateTime.Now;
            entidadActual.Borrado = true;

            var result = await this._data.Configuracion.Update(entidadActual);
            return result > 0;
        }

        public async Task<IEnumerable<TConfiguracion>> ListarAsync()
        {
            return await this._data.Configuracion.SelectIncludes(x => x.Borrado == false);
        }

        public async Task<TConfiguracion> ObtenerAsync(int id)
        {
            return await this._data.Configuracion.GetById(id);
        }

        public async Task<TConfiguracion> ObtenerPorNombre(string value)
        {
            return await this._data.Configuracion.FirstOrDefault(x => x.Nombre.ToUpper().Equals(value.ToUpper()));
        }

        public async Task<decimal> ObtenerValorDecimal(string value)
        {
            var res = await this.ObtenerPorNombre(value);

            if (decimal.TryParse(res.Valor, out decimal result))
            {
                return result;
            }
            return 0;
        }
    }
}
