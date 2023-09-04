using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Cita;

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

        }
    }
}
