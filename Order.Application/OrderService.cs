﻿using AutoMapper;
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
            var order = _mapper.Map<Domain.Order.Order>(createOrderRequest);
            await _orderRepository.SaveAsync(order);
        }

        public async Task AddOrderItemAsync(AddOrderItemRequest addOrderItemRequest)
        {
            var order = await _orderRepository.GetAsync(addOrderItemRequest.OrderId);
            var orderItem = new Domain.Order.OrderItem(addOrderItemRequest.OrderItem.CommodityId, addOrderItemRequest.OrderItem.CommodityName, addOrderItemRequest.OrderItem.Amount);
            order.AddOrderItem(orderItem);

            await _orderRepository.UpdateAsync(order);
        }
    }
}
