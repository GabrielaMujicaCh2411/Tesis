using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Models.Obra;

namespace Copreter.Profiles
{
    public class ObraProfile : Profile
    {
        public ObraProfile()
        {
            CreateMap<TObra, ObraDto>()
                .ForMember(s => s.EstadoObra, src => src.MapFrom(x => x.IdEstadoObraNavigation != null ? x.IdEstadoObraNavigation.Nombre : string.Empty))
                 .ReverseMap();

            CreateMap<ObraDto, ObraEditableVM>().ReverseMap();

            CreateMap<TObra, ObraEditableVM>().ReverseMap();

            CreateMap<TEstadoObra, ItemDto>()
               .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
               .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
               .ReverseMap();


            CreateMap<ObraxPartidumDto, TObraxPartida>().ReverseMap();
        }
    }
}
