using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Pago;

namespace Copreter.Profiles
{
    public class PagoProfile : Profile
    {
        public PagoProfile()
        {
            CreateMap<TPago, PagoDto>() .ReverseMap();
        }
    }
}
