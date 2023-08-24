using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;

namespace Copreter.Domain.Model.Repository
{
    internal class CopreterData : ICopreterData
    {
        private readonly IRepository<TCita> _cita;

        private readonly IRepository<TCliente> _cliente;

        private readonly IRepository<TCotizacion> _cotizacion;

        private readonly IRepository<TEstadoTrabajador> _estadoTrabajador;

        private readonly IRepository<TEstadoUnidad> _estadoUnidad;

        private readonly IRepository<TFactura> _factura;

        private readonly IRepository<TObra> _obra;

        private readonly IRepository<TPago> _pago;

        private readonly IRepository<TPartida> _partida;

        private readonly IRepository<TPedido> _pedido;

        private readonly IRepository<TRol> _rol;

        private readonly IRepository<TTipoPartida> _tipoPartida;

        private readonly IRepository<TTipoTrabajador> _tipoTrabajador;

        private readonly IRepository<TTipoUnidad> _tipoUnidad;

        private readonly IRepository<TTrabajador> _trabajador;

        private readonly IRepository<TUnidad> _unidad;

        private readonly IRepository<TUsuario> _usuario;

        public CopreterData(
            IRepository<TCita> cita,
            IRepository<TCliente> cliente,
            IRepository<TCotizacion> cotizacion,
            IRepository<TEstadoTrabajador> estadoTrabajador,
            IRepository<TEstadoUnidad> estadoUnidad,
            IRepository<TFactura> factura,
            IRepository<TObra> obra,
            IRepository<TPago> pago,
            IRepository<TPartida> partida,
            IRepository<TPedido> pedido,
            IRepository<TRol> rol,
            IRepository<TTipoPartida> tipoPartida,
            IRepository<TTipoTrabajador> tipoTrabajador,
            IRepository<TTipoUnidad> tipoUnidad,
            IRepository<TTrabajador> trabajador,
            IRepository<TUnidad> unidad,
            IRepository<TUsuario> usuario)
        {
            this._cita = cita;
            this._cliente = cliente;
            this._cotizacion = cotizacion;
            this._estadoTrabajador = estadoTrabajador;
            this._estadoUnidad = estadoUnidad;
            this._factura = factura;
            this._obra = obra;
            this._pago = pago;
            this._partida = partida;
            this._pedido = pedido;
            this._rol = rol;
            this._tipoPartida = tipoPartida;
            this._tipoTrabajador = tipoTrabajador;
            this._tipoUnidad = tipoUnidad;
            this._trabajador = trabajador;
            this._unidad = unidad;
            this._usuario = usuario;
        }

        public IRepository<TCita> Cita => this._cita;

        public IRepository<TCliente> Cliente => this._cliente;

        public IRepository<TCotizacion> Cotizacion => this._cotizacion;

        public IRepository<TEstadoTrabajador> EstadoTrabajador => this._estadoTrabajador;

        public IRepository<TEstadoUnidad> EstadoUnidad => this._estadoUnidad;

        public IRepository<TFactura> Factura => this._factura;

        public IRepository<TObra> Obra => this._obra;

        public IRepository<TPago> Pago => this._pago;

        public IRepository<TPartida> Partida => this._partida;

        public IRepository<TPedido> Pedido => this._pedido;

        public IRepository<TRol> Rol => this._rol;

        public IRepository<TTipoPartida> TipoPartida => this._tipoPartida;

        public IRepository<TTipoTrabajador> TipoTrabajador => this._tipoTrabajador;

        public IRepository<TTipoUnidad> TipoUnidad => this._tipoUnidad;

        public IRepository<TTrabajador> Trabajador => this._trabajador;

        public IRepository<TUnidad> Unidad => this._unidad;

        public IRepository<TUsuario> Usuario => this._usuario;
    }
}
