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
            CreateMap<Domain.Order.Order, Contracts.Dto.OrderCreationDto>();
            CreateMap<Domain.Order.OrderItem, Domain.Order.OrderItem>();

            CreateMap<Domain.Order.Order, Contracts.Eto.OrderChangedEto>();
        }
    }
}
