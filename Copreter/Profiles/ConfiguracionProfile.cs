using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Configuracion;
using Copreter.Models.Configuracion;

namespace Copreter.Profiles
{
    public class ConfiguracionProfile : Profile
    {
        public ConfiguracionProfile()
        {
            CreateMap<TConfiguracion, ConfiguracionEditableVM>().ReverseMap();


            CreateMap<TConfiguracion, ConfiguracionDto>().ReverseMap();
        }
    }
}
