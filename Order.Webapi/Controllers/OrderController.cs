using Microsoft.AspNetCore.Mvc;
using Order.Application;
using Order.Application.Contracts.Dto;

namespace Order.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(OrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync(int orderId)
        {
            var order = await _orderService.GetAsync(orderId);
            return new JsonResult(order);
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllAsync()
        {
            var orders = await _orderService.GetAllAsync();
            return new JsonResult(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(OrderCreationDto orderCreationDto)
        {
            _logger.LogInformation("Create {@orderCreationDto}", orderCreationDto);
            var order = await _orderService.CreateAsync(orderCreationDto);
            return Ok(order);
        }

        [HttpPost("AddOrderItem")]
        public async Task<ActionResult> AddOrderItemAsync(OrderItemCreationDto orderItemCreationDto)
        {
            var order = await _orderService.AddOrderItemAsync(orderItemCreationDto);
            return Ok(order);
        }
    }
}
