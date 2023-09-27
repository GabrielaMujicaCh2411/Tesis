using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.CotizacionxUnidad;

namespace Copreter.Profiles
{
    public class CotizacionxUnidadProfile : Profile
    {
        public CotizacionxUnidadProfile()
        {
            CreateMap<AUnidadDto, TCotizacionxUnidad>()
                .ForMember(s => s.IdUnidad, src => src.MapFrom(x => x.Id))
                .ForMember(s => s.Cantidad, src => src.MapFrom(x => x.Cantidad))
                .ForMember(s => s.IdCotizacion, src => src.MapFrom(x => x.IdCotizacion))
                .ReverseMap();
        }
    }
}
