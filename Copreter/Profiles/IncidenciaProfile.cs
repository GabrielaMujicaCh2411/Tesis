using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Incidencia;
using Copreter.Models.Incidencia;

namespace Copreter.Profiles
{
    public class IncidenciaProfile : Profile
    {
        public IncidenciaProfile()
        {
            CreateMap<TIncidencia, IncidenciaDto>()
               .ForMember(s => s.Pedido, src => src.MapFrom(x => x.IdPedidoNavigation != null ? x.IdPedidoNavigation.Obra : string.Empty))
                .ReverseMap();


            CreateMap<TIncidencia, IncidenciaEditableVM>()
               .ForMember(s => s.Pedido, src => src.MapFrom(x => x.IdPedidoNavigation != null ? x.IdPedidoNavigation.Obra : string.Empty))
               .ReverseMap();
        }
    }
}
