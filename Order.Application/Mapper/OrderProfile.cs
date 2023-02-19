using AutoMapper;
using Order.Application.DTO;

namespace Order.Application.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderRequest, Domain.Order.Order>();
        }
    }
}
