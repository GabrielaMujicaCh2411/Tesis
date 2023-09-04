using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.TipoPartida;
using Copreter.Models.TipoPartida;

namespace Copreter.Profiles
{
    public class TipoPartidaProfile: Profile
    {
        public TipoPartidaProfile()
        {
            CreateMap<TTipoPartida, TipoPartidaDto>().ReverseMap();

            CreateMap<TTipoPartida, TipoPartidaEditableVM>().ReverseMap();

            CreateMap<TTipoPartida, ItemDto>()
               .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
               .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
               .ReverseMap();
        }
    }
}
