using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Cotizacion;
using Copreter.Models.Cotizacion;

namespace Copreter.Profiles
{
    public class CotizacionProfile : Profile
    {
        public CotizacionProfile()
        {
            CreateMap<TCotizacion, CotizacionDto>()
                .ForMember(s => s.EstadoCotizacion, src => src.MapFrom(x => x.IdEstadoCotizacionNavigation != null ? x.IdEstadoCotizacionNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<TEstadoCotizacion, ItemDto>()
               .ForMember(s => s.Id, src => src.MapFrom(x => x.Id))
               .ForMember(s => s.Name, src => src.MapFrom(x => x.Nombre))
               .ReverseMap();

            CreateMap<CotizarDto, TCotizacion>()
                .ForMember(s => s.IdObra, src => src.MapFrom(x => x.IdObra))
               .ForMember(s => s.Total, src => src.MapFrom(x => x.Total))
               .ReverseMap();

            CreateMap<TCotizacion, CotizacionEditableVM>().ReverseMap();


        }
    }
}
