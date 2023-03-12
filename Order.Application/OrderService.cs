using AutoMapper;
using Order.Application.Contracts.Dto;
using Order.Application.Contracts.Eto;
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
        private readonly OrderManager orderManager;
        private readonly IDistributedEventBus distributedEventBus;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, OrderManager orderManager, IDistributedEventBus distributedEventBus)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            this.orderManager = orderManager;
            this.distributedEventBus = distributedEventBus;
        }

        public async Task<OrderDto> GetAsync(int orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> CreateAsync(OrderCreationDto orderCreationDto)
        {
            var order = await orderManager.CreateAsync(orderCreationDto.OrderCode);
            order.OrderItems = orderCreationDto.OrderItems.Select(i => new Domain.Order.OrderItem(i.CommodityId, i.CommodityName, i.Amount)).ToList();
            order.CreatedBy = orderCreationDto.CreatedBy;
            order.Weight = orderCreationDto.Weight;

            var savedOrder = await _orderRepository.InsertAsync(order);
            order.OrderId = savedOrder.OrderId;

            await distributedEventBus.PublishAsync(_mapper.Map<OrderChangedEto>(order));
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> AddOrderItemAsync(OrderItemCreationDto orderItemCreationDto)
        {
            var order = await _orderRepository.GetAsync(orderItemCreationDto.OrderId);
            var orderItem = new Domain.Order.OrderItem(orderItemCreationDto.OrderItem.CommodityId, orderItemCreationDto.OrderItem.CommodityName, orderItemCreationDto.OrderItem.Amount);
            order.AddOrderItem(orderItem);
            await _orderRepository.UpdateAsync(order);

            return _mapper.Map<OrderDto>(order);
        }
    }
}
