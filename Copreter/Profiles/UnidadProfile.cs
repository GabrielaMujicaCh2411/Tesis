using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Unidad;
using Copreter.Models.Unidad;

namespace Copreter.Profiles
{
    public class UnidadProfile : Profile
    {
        public UnidadProfile()
        {
            CreateMap<TUnidad, UnidadDto>()
                .ForMember(s => s.EstadoUnidad, src => src.MapFrom(x => x.IdEstadoUnidadNavigation != null ? x.IdEstadoUnidadNavigation.Nombre : string.Empty))
                .ForMember(s => s.TipoUnidad, src => src.MapFrom(x => x.IdTipoUnidadNavigation != null ? x.IdTipoUnidadNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<TEstadoUnidad, ItemDto>()
                .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
                .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
                .ReverseMap();

            CreateMap<TTipoUnidad, ItemDto>()
                .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
                .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
                .ReverseMap();

            CreateMap<TUnidad, UnidadEditableVM>().ReverseMap();
        }
    }
}
