using Copreter.Domain.Model.DbModel;

namespace Copreter.Domain.Model.Repository.Interfaces
{
    public interface ICopreterData
    {
        IRepository<TCita> Cita { get; }

        IRepository<TCliente> Cliente { get; }

        IRepository<TCotizacion> Cotizacion { get; }

        IRepository<TFactura> Factura { get; }

        IRepository<TObra> Obra { get; }

        IRepository<TPago> Pago { get; }

        IRepository<TPartida> Partida { get; }

        IRepository<TTipoPartida> TipoPartida { get; }
    }
}
