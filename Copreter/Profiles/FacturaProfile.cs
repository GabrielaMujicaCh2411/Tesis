using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.Factura;

namespace Copreter.Profiles
{
    public class FacturaProfile : Profile
    {
        public FacturaProfile()
        {
            CreateMap<FacturaDto, TFactura>().ReverseMap();

        }
    }
}
