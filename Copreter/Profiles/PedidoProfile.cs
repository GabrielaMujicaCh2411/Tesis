using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Pedido;

namespace Copreter.Profiles
{
    public class PedidoProfile: Profile
    {
        public PedidoProfile()
        {
            CreateMap<TPedido, PedidoDto>()
             .ForMember(s => s.EstadoPedido, src => src.MapFrom(x => x.IdEstadoPedidoNavigation != null ? x.IdEstadoPedidoNavigation.Nombre : string.Empty))
             .ReverseMap();
        }
    }
}
