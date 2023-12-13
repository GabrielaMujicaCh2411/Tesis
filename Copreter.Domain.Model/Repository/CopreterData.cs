using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;

namespace Copreter.Domain.Model.Repository
{
    internal class CopreterData : ICopreterData
    {
        private readonly IRepository<TCita> _cita;

        private readonly IRepository<TAdenda> _adenda;

        private readonly IRepository<TAcceso> _acceso;

        private readonly IRepository<TCotizacion> _cotizacion;

        private readonly IRepository<TCotizacionxUnidad> _cotizacionXUnidad;

        private readonly IRepository<TEstadoCotizacion> _estadoCotizacion;

        private readonly IRepository<TEstadoObra> _estadoObra;

        private readonly IRepository<TEstadoPedido> _estadoPedido;

        private readonly IRepository<TEstadoTrabajador> _estadoTrabajador;

        private readonly IRepository<TEstadoUnidad> _estadoUnidad;

        private readonly IRepository<TFactura> _factura;

        private readonly IRepository<TIncidencia> _incidencia;

        private readonly IRepository<TObra> _obra;

        private readonly IRepository<TObraIncidencia> _obraIncidencia;

        private readonly IRepository<TObraxPartida> _obraPartida;

        private readonly IRepository<TOrdenServicio> _ordenServicio;

        private readonly IRepository<TPago> _pago;

        private readonly IRepository<TPartida> _partida;

        private readonly IRepository<TPedido> _pedido;

        private readonly IRepository<TPedidoOrdenServicio> _pedidoOrdenServicio;

        private readonly IRepository<TPedidoSolicitud> _pedidoSolicitud;

        private readonly IRepository<TRol> _rol;

        private readonly IRepository<TTipoPartida> _tipoPartida;

        private readonly IRepository<TTipoTrabajador> _tipoTrabajador;

        private readonly IRepository<TTipoUnidad> _tipoUnidad;

        private readonly IRepository<TTrabajador> _trabajador;

        private readonly IRepository<TTrabajadorxCotizacion> _trabajadorxCotizacion;

        private readonly IRepository<TUnidad> _unidad;

        private readonly IRepository<TUsuario> _usuario;

        public CopreterData(
            IRepository<TCita> cita,
             IRepository<TAdenda> adenda,
            IRepository<TAcceso> acceso,
            IRepository<TCotizacion> cotizacion,
            IRepository<TCotizacionxUnidad> cotizacionXUnidad,
            IRepository<TEstadoCotizacion> estadoCotizacion,
            IRepository<TEstadoObra> estadoObra,
            IRepository<TEstadoPedido> estadoPedido,
            IRepository<TEstadoTrabajador> estadoTrabajador,
            IRepository<TEstadoUnidad> estadoUnidad,
            IRepository<TFactura> factura,
            IRepository<TIncidencia> incidencia,
            IRepository<TObra> obra,
            IRepository<TObraIncidencia> obraIncidencia,
            IRepository<TObraxPartida> obraPartida,
            IRepository<TOrdenServicio> ordenServicio,
            IRepository<TPago> pago,
            IRepository<TPartida> partida,
            IRepository<TPedido> pedido,
            IRepository<TPedidoOrdenServicio> pedidoOrdenServicio,
            IRepository<TPedidoSolicitud> pedidoSolicitud,
            IRepository<TRol> rol,
            IRepository<TTipoPartida> tipoPartida,
            IRepository<TTipoTrabajador> tipoTrabajador,
            IRepository<TTipoUnidad> tipoUnidad,
            IRepository<TTrabajador> trabajador,
            IRepository<TTrabajadorxCotizacion> trabajadorxCotizacion,
            IRepository<TUnidad> unidad,
            IRepository<TUsuario> usuario)
        {
            this._cita = cita;
            this._adenda = adenda;
            this._acceso = acceso;
            this._cotizacion = cotizacion;
            this._cotizacionXUnidad = cotizacionXUnidad;
            this._estadoCotizacion = estadoCotizacion;
            this._estadoPedido = estadoPedido;
            this._estadoObra = estadoObra;
            this._estadoTrabajador = estadoTrabajador;
            this._estadoUnidad = estadoUnidad;
            this._factura = factura;
            this._incidencia = incidencia;
            this._obra = obra;
            this._obraIncidencia = obraIncidencia;
            this._obraPartida = obraPartida;
            this._ordenServicio = ordenServicio;
            this._pago = pago;
            this._partida = partida;
            this._pedido = pedido;
            this._pedidoOrdenServicio = pedidoOrdenServicio;
            this._pedidoSolicitud = pedidoSolicitud;
            this._rol = rol;
            this._tipoPartida = tipoPartida;
            this._tipoTrabajador = tipoTrabajador;
            this._tipoUnidad = tipoUnidad;
            this._trabajador = trabajador;
            this._trabajadorxCotizacion = trabajadorxCotizacion;
            this._unidad = unidad;
            this._usuario = usuario;
        }

        public IRepository<TCita> Cita => this._cita;

        public IRepository<TAdenda> Adenda => this._adenda;

        public IRepository<TAcceso> Acceso => this._acceso;

        public IRepository<TCotizacion> Cotizacion => this._cotizacion;

        public IRepository<TCotizacionxUnidad> CotizacionXUnidad => this._cotizacionXUnidad;

        public IRepository<TEstadoCotizacion> EstadoCotizacion => this._estadoCotizacion;

        public IRepository<TEstadoObra> EstadoObra => this._estadoObra;

        public IRepository<TEstadoPedido> EstadoPedido => this._estadoPedido;

        public IRepository<TEstadoTrabajador> EstadoTrabajador => this._estadoTrabajador;

        public IRepository<TEstadoUnidad> EstadoUnidad => this._estadoUnidad;

        public IRepository<TFactura> Factura => this._factura;

        public IRepository<TIncidencia> Incidencia => this._incidencia;

        public IRepository<TObra> Obra => this._obra;

        public IRepository<TObraIncidencia> ObraIncidencia => this._obraIncidencia;

        public IRepository<TObraxPartida> ObraPartida => this._obraPartida;

        public IRepository<TOrdenServicio> OrdenServicio => this._ordenServicio;

        public IRepository<TPago> Pago => this._pago;

        public IRepository<TPartida> Partida => this._partida;

        public IRepository<TPedido> Pedido => this._pedido;

        public IRepository<TPedidoOrdenServicio> PedidoOrdenServicio => this._pedidoOrdenServicio;

        public IRepository<TPedidoSolicitud> PedidoSolicitud => this._pedidoSolicitud;

        public IRepository<TRol> Rol => this._rol;

        public IRepository<TTipoPartida> TipoPartida => this._tipoPartida;

        public IRepository<TTipoTrabajador> TipoTrabajador => this._tipoTrabajador;

        public IRepository<TTipoUnidad> TipoUnidad => this._tipoUnidad;

        public IRepository<TTrabajador> Trabajador => this._trabajador;

        public IRepository<TTrabajadorxCotizacion> TrabajadorxCotizacion => this._trabajadorxCotizacion;

        public IRepository<TUnidad> Unidad => this._unidad;

        public IRepository<TUsuario> Usuario => this._usuario;


    }
}
