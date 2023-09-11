using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Cita;
using Copreter.Models.Cita;

namespace Copreter.Profiles
{
    public class CitaProfile : Profile
    {
        public CitaProfile()
        {
            CreateMap<TCita, CitaDto>()
            .ForMember(s => s.NombreObra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.NombreObra : string.Empty))
            .ForMember(s => s.NombreEmpresa, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.Empresa : string.Empty))
            .ReverseMap();

            CreateMap<TCita, CitaEditableVM>()
            .ForMember(s => s.NombreObra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.NombreObra : string.Empty))
            .ForMember(s => s.NombreEmpresa, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.Empresa : string.Empty))
            .ForMember(s => s.Direccion, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.Direccion : string.Empty))
            .ForMember(s => s.FechaInicio, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.FechaInicio : DateTime.Now))
            .ForMember(s => s.DuracionObra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.DuracionObra :0))
            .ForMember(s => s.IdUsuario, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.IdUsuario : 0))
            .ForMember(s => s.EstadoObra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.IdEstadoObraNavigation.Nombre : string.Empty))
            .ReverseMap();

            CreateMap<TCita, CitaDetalleDto>()
            .ForMember(s => s.NombreObra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.NombreObra : string.Empty))
            .ForMember(s => s.NombreEmpresa, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.Empresa : string.Empty))
            .ForMember(s => s.Direccion, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.Direccion : string.Empty))
            .ForMember(s => s.FechaInicio, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.FechaInicio : DateTime.Now))
            .ForMember(s => s.DuracionObra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.DuracionObra : 0))
            .ForMember(s => s.IdUsuario, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.IdUsuario : 0))
            .ForMember(s => s.EstadoObra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.IdEstadoObraNavigation.Nombre : string.Empty))            
            .ReverseMap();

        }
    }
}
