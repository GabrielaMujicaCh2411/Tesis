using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Models.Partida;

namespace Copreter.Profiles
{
    public class PartidaProfile : Profile
    {
        public PartidaProfile()
        {
            CreateMap<TPartida, PartidaEditableVM>().ReverseMap();

            CreateMap<TPartida, PartidaDto>()
             .ForMember(s => s.TipoPartida, src => src.MapFrom(x => x.IdTipoPartidaNavigation != null ? x.IdTipoPartidaNavigation.Nombre : string.Empty))
             .ReverseMap();
        }
    }
}
