using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Obra;
using Copreter.Models.Obra;

namespace Copreter.Profiles
{
    public class ObraProfile : Profile
    {
        public ObraProfile()
        {
            CreateMap<TObra, ObraDto>()
                //.ForMember(s => s.TipoTrabajador, src => src.MapFrom(x => x.IdTipoTrabajadorNavigation != null ? x.IdTipoTrabajadorNavigation.Nombre : string.Empty))
                //.ForMember(s => s.EstadoTrabajador, src => src.MapFrom(x => x.IdEstadoTrabajadorNavigation != null ? x.IdEstadoTrabajadorNavigation.Nombre : string.Empty))
                 .ReverseMap();

            CreateMap<TObra, ObraEditableVM>().ReverseMap();

            CreateMap<TEstadoObra, ItemDto>()
               .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
               .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
               .ReverseMap();
        }
    }
}
