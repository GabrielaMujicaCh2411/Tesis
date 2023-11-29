using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Pedido;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Pedido;
using Copreter.Models.Pedido;

namespace Copreter.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<TPedido, PedidoDto>()
             .ForMember(s => s.EstadoPedido, src => src.MapFrom(x => x.IdEstadoPedidoNavigation != null ? x.IdEstadoPedidoNavigation.Nombre : string.Empty))
             .ForMember(s => s.IdTipoUnidad, src => src.MapFrom(x => x.IdUnidadNavigation != null ? x.IdUnidadNavigation.IdTipoUnidad : 0))
             .ForMember(s => s.TipoUnidad, src => src.MapFrom(x => x.IdUnidadNavigation != null && x.IdUnidadNavigation.IdTipoUnidadNavigation != null ? x.IdUnidadNavigation.IdTipoUnidadNavigation.Nombre : string.Empty))
             .ReverseMap();

            CreateMap<PedidoDto, TPedidoSolicitud>()
                .ReverseMap();

            CreateMap<TEstadoPedido, ItemDto>()
               .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
               .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
               .ReverseMap();

            CreateMap<TPedido, PedidoEditableVM>()
                .ForMember(s => s.PrecioUnidad, src => src.MapFrom(x => x.IdUnidadNavigation != null && x.IdUnidadNavigation.Precio != null ? x.IdUnidadNavigation.Precio : 0))
                .ReverseMap();

            CreateMap<PedidoOrden, PedidoEditableVM>()
                .ForMember(s => s.PrecioUnidad, src => src.MapFrom(x => x.IdUnidadNavigation != null && x.IdUnidadNavigation.Precio != null ? x.IdUnidadNavigation.Precio : 0))
                .ReverseMap();

            CreateMap<PedidoDto, PedidoEditableVM>().ReverseMap();
        }
    }
}
