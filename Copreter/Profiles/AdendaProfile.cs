using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Adenda;
using Copreter.Domain.Service.Dto.OrdenServicio;

namespace Copreter.Profiles
{
    public class AdendaProfile : Profile
    {
        public AdendaProfile()
        {
            CreateMap<TAdenda, AdendaDto>().ReverseMap();
        }
    }
}
