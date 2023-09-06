using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Acceso;
using Copreter.Models.Acceso;

namespace Copreter.Profiles
{
    public class AccesoProfile : Profile
    {
        public AccesoProfile()
        {
            CreateMap<TUsuario, AccesoDto>().ReverseMap();
            CreateMap<TAcceso, AccesoDto>()
                .ForMember(s => s.Dni, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Dni : 0))
                .ForMember(s => s.Nombre, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Nombre : string.Empty))
                .ForMember(s => s.Apellido, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Apellido : string.Empty))
                .ForMember(s => s.Celular, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Celular : 0))
                .ForMember(s => s.Direccion, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Direccion : string.Empty))
                .ForMember(s => s.Rol, src => src.MapFrom(x => x.IdRolNavigation != null ? x.IdRolNavigation.Nombre : string.Empty))
                .ReverseMap();


            CreateMap<TAcceso, AccesoEditableVM>()
                .ForMember(s => s.Dni, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Dni : 0))
                .ForMember(s => s.Nombre, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Nombre : string.Empty))
                .ForMember(s => s.Apellido, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Apellido : string.Empty))
                .ForMember(s => s.Celular, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Celular : 0))
                .ForMember(s => s.Direccion, src => src.MapFrom(x => x.IdUsuarioNavigation != null ? x.IdUsuarioNavigation.Direccion : string.Empty))
                .ForMember(s => s.Rol, src => src.MapFrom(x => x.IdRolNavigation != null ? x.IdRolNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<AccesoDto, AccesoEditableVM>().ReverseMap();
        }
    }
}