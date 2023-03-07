using AutoMapper;
using Order.Application.Contracts.Dto;

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
