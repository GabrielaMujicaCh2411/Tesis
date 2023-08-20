using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Cliente;

namespace Copreter.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<TCliente, ClienteDto>().ReverseMap();

            CreateMap<ClienteDto, TUsuario>()
                .ForMember(s => s.Contrasenya, src => src.MapFrom(x => x.Dni)).ReverseMap();


        }
    }
}
