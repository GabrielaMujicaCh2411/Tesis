using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Cotizacion;

namespace Copreter.Profiles
{
    public class CotizacionProfile : Profile
    {
        public CotizacionProfile()
        {
            CreateMap<TCotizacion, CotizacionDto>()
                .ForMember(s => s.EstadoCotizacion, src => src.MapFrom(x => x.IdEstadoCotizacionNavigation != null ? x.IdEstadoCotizacionNavigation.Nombre : string.Empty))
                .ReverseMap();
        }
    }
}
