using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Model.Repository.Interfaces
{
    public interface ICopreterData
    {
        IRepository<TCita> Cita { get; }

        IRepository<TAdenda> Adenda { get; }

        IRepository<TAcceso> Acceso { get; }

        IRepository<TEstadoCotizacion> EstadoCotizacion { get; }

        IRepository<TEstadoObra> EstadoObra { get; }

        IRepository<TEstadoPedido> EstadoPedido { get; }

        IRepository<TEstadoTrabajador> EstadoTrabajador {get;}

        IRepository<TEstadoUnidad> EstadoUnidad { get; }

        IRepository<TCotizacion> Cotizacion { get; }

        IRepository<TCotizacionxUnidad> CotizacionXUnidad { get; }

        IRepository<TFactura> Factura { get; }

        IRepository<TIncidencia> Incidencia { get; }

        IRepository<TObra> Obra { get; }

        IRepository<TObraIncidencia> ObraIncidencia { get; }

        IRepository<TObraxPartida> ObraPartida { get; }

        IRepository<TOrdenServicio> OrdenServicio { get; }

        IRepository<TPago> Pago { get; }

        IRepository<TPartida> Partida { get; }

        IRepository<TPedido> Pedido { get; }

        IRepository<TPedidoOrdenServicio> PedidoOrdenServicio { get; }

        IRepository<TPedidoSolicitud> PedidoSolicitud { get; }

        IRepository<TRol> Rol { get; }

        IRepository<TTipoPartida> TipoPartida { get; }

        IRepository<TTipoTrabajador> TipoTrabajador { get; }

        IRepository<TTipoUnidad> TipoUnidad { get; }

        IRepository<TTrabajador> Trabajador { get; }

        IRepository<TTrabajadorxCotizacion> TrabajadorxCotizacion { get; }

        IRepository<TUnidad> Unidad { get; }

        IRepository<TUsuario> Usuario { get; }
    }
}
