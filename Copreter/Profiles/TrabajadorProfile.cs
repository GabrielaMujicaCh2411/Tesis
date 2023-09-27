using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Domain.Service.Dto.TrabajadorxCotizacion;
using Copreter.Models.Trabajador;

namespace Copreter.Profiles
{
    public class TrabajadorProfile : Profile
    {
        public TrabajadorProfile()
        {
            CreateMap<TTrabajador, TrabajadorDto>()
               .ForMember(s => s.TipoTrabajador, src => src.MapFrom(x => x.IdTipoTrabajadorNavigation != null ? x.IdTipoTrabajadorNavigation.Nombre : string.Empty))
               .ForMember(s => s.EstadoTrabajador, src => src.MapFrom(x => x.IdEstadoTrabajadorNavigation != null ? x.IdEstadoTrabajadorNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<TTrabajador, TrabajadorEditableVM>().ReverseMap();

            CreateMap<TrabajadorDto, TrabajadorEditableVM>().ReverseMap();

            CreateMap<TTrabajador, ItemDto>()
                .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
                .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
                .ReverseMap();

            CreateMap<TEstadoTrabajador, ItemDto>()
               .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
               .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
               .ReverseMap();

            CreateMap<TTipoTrabajador, ItemDto>()
                .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
                .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
                .ReverseMap();

            CreateMap<TTrabajador, ATrabajadorDto>().ReverseMap();
        }
    }
}
