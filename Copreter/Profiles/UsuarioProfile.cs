using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Usuario;

namespace Copreter.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<TUsuario, UsuarioDto>().ReverseMap();

            CreateMap<UsuarioDto, TAcceso>()
                .ForMember(s => s.Contrasenya, src => src.MapFrom(x => x.Dni)).ReverseMap();

        }
    }
}
