using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Domain.Service.Dto.TrabajadorxCotizacion;

namespace Copreter.Profiles
{
    public class TrabajadorxCotizacionProfile : Profile
    {
        public TrabajadorxCotizacionProfile()
        {
            CreateMap<ATrabajadorDto, TTrabajadorxCotizacion>()
                .ForMember(s => s.IdTrabajador, src => src.MapFrom(x => x.Id))
                .ForMember(s => s.IdCotizacion, src => src.MapFrom(x => x.IdCotizacion))
                .ReverseMap();
        }
    }
}
