using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;

namespace Copreter.Profiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<TRol, ItemDto>()
                .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
                .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
                .ReverseMap();
        }
    }
}
