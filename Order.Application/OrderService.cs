using AutoMapper;
using Order.Application.Contracts.Dto;
using Order.Domain.Order;

namespace Order.Application
{
    /**
     * An Application Service is a stateless service that implements use cases of the application.
       An application service typically gets and returns DTOs. It is used by the Presentation Layer.
       It uses and coordinates the domain objects (entities, repositories, etc.) to implement the use cases.
     */
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(OrderCreationDto createOrderRequest)
        {
            var order = _mapper.Map<Domain.Order.Order>(createOrderRequest);
            await _orderRepository.InsertAsync(order);
        }

        public async Task AddOrderItemAsync(AddOrderItemRequest addOrderItemRequest)
        {
            var order = await _orderRepository.GetAsync(addOrderItemRequest.OrderId);
            var orderItem = _mapper.Map<Domain.Order.OrderItem>(addOrderItemRequest.OrderItem);
            order.AddOrderItem(orderItem);
            await _orderRepository.UpdateAsync(order);
        }
    }
}
