using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;

namespace Copreter.Domain.Model.Repository
{
    internal class CopreterData : ICopreterData
    {
        public IRepository<TCita> Cita => throw new NotImplementedException();

        public IRepository<TCliente> Cliente => throw new NotImplementedException();

        public IRepository<TCotizacion> Cotizacion => throw new NotImplementedException();

        public IRepository<TFactura> Factura => throw new NotImplementedException();

        public IRepository<TObra> Obra => throw new NotImplementedException();

        public IRepository<TPago> Pago => throw new NotImplementedException();

        public IRepository<TPartida> Partida => throw new NotImplementedException();

        public IRepository<TPedido> Pedido => throw new NotImplementedException();

        public IRepository<TRol> Rol => throw new NotImplementedException();

        public IRepository<TTipoPartida> TipoPartida => throw new NotImplementedException();

        public IRepository<TTipoUnidad> TipoUnidad => throw new NotImplementedException();

        public IRepository<TTrabajador> Trabajador => throw new NotImplementedException();

        public IRepository<TUnidad> Unidad => throw new NotImplementedException();

        public IRepository<TUsuario> Usuario => throw new NotImplementedException();
    }
}
