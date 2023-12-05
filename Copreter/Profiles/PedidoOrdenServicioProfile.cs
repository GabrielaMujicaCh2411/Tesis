using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Dto.PedidoOrdenServicio;

namespace Copreter.Profiles
{
    public class PedidoOrdenServicioProfile : Profile
    {
        public PedidoOrdenServicioProfile()
        {

            CreateMap<TPedidoOrdenServicio, PedidoOrdenServicioDto>() .ReverseMap();
        }
    }
}
