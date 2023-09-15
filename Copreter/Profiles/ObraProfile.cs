using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Models.Cotizacion;
using Copreter.Models.Obra;

namespace Copreter.Profiles
{
    public class ObraProfile : Profile
    {
        public ObraProfile()
        {
            CreateMap<TObra, ObraDto>()
                .ForMember(s => s.EstadoObra, src => src.MapFrom(x => x.IdEstadoObraNavigation != null ? x.IdEstadoObraNavigation.Nombre : string.Empty))
                .ForMember(s => s.Cliente, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? $"{x.IdUsuarioNavigation.Nombre} {x.IdUsuarioNavigation.Apellido}" : string.Empty))
                 .ReverseMap();

            CreateMap<ObraDto, ObraEditableVM>().ReverseMap();

            CreateMap<TObra, ObraEditableVM>()
                .ForMember(s => s.EstadoObra, src => src.MapFrom(x => x.IdEstadoObraNavigation != null ? x.IdEstadoObraNavigation.Nombre : string.Empty))
                .ForMember(s => s.Cliente, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? $"{x.IdUsuarioNavigation.Nombre} {x.IdUsuarioNavigation.Apellido}" : string.Empty))
                .ReverseMap();

            CreateMap<TEstadoObra, ItemDto>()
               .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
               .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
               .ReverseMap();


            CreateMap<ObraxPartidumDto, TObraxPartida>().ReverseMap();

            CreateMap<TObraxPartida, ObraPartidaDto>()
                .ForMember(s => s.Partida, src => src.MapFrom(x => x.IdPartidaNavigation != null ? x.IdPartidaNavigation.Nombre : string.Empty))
                .ReverseMap();

            //CreateMap<TObraxPartida, CotizacionEditableVM>()
            //    .ForMember(s => s.Empresa, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.Empresa : string.Empty))
            //    .ForMember(s => s.Fecha, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.FechaInicio : DateTime.Now))
            //    .ForMember(s => s.Direccion, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.Direccion : string.Empty))
            //    .ReverseMap();
        }
    }
}
