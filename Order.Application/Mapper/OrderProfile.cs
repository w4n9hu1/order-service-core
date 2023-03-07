using AutoMapper;

namespace Order.Application.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Contracts.Dto.OrderItem, Domain.Order.OrderItem>();
            CreateMap<Contracts.Dto.CreateOrderRequest, Domain.Order.Order>();
        }
    }
}
