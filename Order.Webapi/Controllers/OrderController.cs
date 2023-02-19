using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Order.Application.DTO;
using Order.Domain.Order;

namespace Order.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            await Task.Delay(1000);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CreateOrderRequest createOrderRequest)
        {
            var order = _mapper.Map<Domain.Order.Order>(createOrderRequest);
            await _orderRepository.SaveOrderAsync(order);
            return Ok();
        }
    }
}
