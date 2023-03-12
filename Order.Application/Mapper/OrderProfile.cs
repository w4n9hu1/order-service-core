using AutoMapper;

namespace Order.Application.Mapper
{
    public class OrderProfile : Profile
    {
        /**
         * Object to Object Mapping
         */
        public OrderProfile()
        {
            CreateMap<Domain.Order.Order, Contracts.Dto.OrderDto>();
            CreateMap<Domain.Order.OrderItem, Contracts.Dto.OrderItem>();

            CreateMap<Domain.Order.Order, Contracts.Eto.OrderChangedEto>();
        }
    }
}
