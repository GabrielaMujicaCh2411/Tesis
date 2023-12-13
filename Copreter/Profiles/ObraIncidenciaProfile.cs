using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.ObraIncidencia;
using Copreter.Models.ObraIncidencia;

namespace Copreter.Profiles
{
    public class ObraIncidenciaProfile : Profile
    {
        public ObraIncidenciaProfile()
        {
            CreateMap<TObraIncidencia, ObraIncidenciaDto>()
               .ForMember(s => s.Obra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.NombreObra : string.Empty))
                .ReverseMap();


            CreateMap<TObraIncidencia, ObraIncidenciaEditableVM>()
               .ForMember(s => s.Obra, src => src.MapFrom(x => x.IdObraNavigation != null ? x.IdObraNavigation.NombreObra : string.Empty))
               .ReverseMap();
        }
    }
}
