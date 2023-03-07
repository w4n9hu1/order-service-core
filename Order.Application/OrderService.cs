using AutoMapper;
using Order.Application.Contracts.Dto;
using Order.Domain.Order;

namespace Order.Application
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateOrderRequest createOrderRequest)
        {
            var order = new Domain.Order.Order(createOrderRequest.OrderCode, _mapper.Map<List<Domain.Order.OrderItem>>(createOrderRequest.OrderItems))
            {
                Weight = createOrderRequest.Weight,
                CreatedBy = createOrderRequest.CreatedBy,
                CreatedTime = DateTimeOffset.Now
            };
            await _orderRepository.SaveAsync(order);
        }

        public async Task AddOrderItemAsync(AddOrderItemRequest addOrderItemRequest)
        {
            var order = await _orderRepository.GetAsync(addOrderItemRequest.OrderId);
            var orderItem = _mapper.Map<Domain.Order.OrderItem>(addOrderItemRequest.OrderItem);
            order.AddOrderItem(orderItem);

            await _orderRepository.SaveAsync(order);
        }
    }
}
