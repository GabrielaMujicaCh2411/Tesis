using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.OrdenServicio;

namespace Copreter.Profiles
{
    public class OrdenServicioProfile : Profile
    {
        public OrdenServicioProfile()
        {
            CreateMap<TOrdenServicio, OrdenServicioDto>().ReverseMap();
        }
    }
}
