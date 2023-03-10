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
        public async Task<ActionResult> GetAsync()
        {
            _logger.LogInformation("GetAsync");
            _logger.LogWarning("warn GetAsync");
            await Task.Delay(1000);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateOrderRequest createOrderRequest)
        {
            await _orderService.CreateAsync(createOrderRequest);
            return Ok();
        }

        [HttpPost("AddOrderItem")]
        public async Task<ActionResult> AddOrderItemAsync(AddOrderItemRequest addOrderItemRequest)
        {
            await _orderService.AddOrderItemAsync(addOrderItemRequest);
            return Ok();
        }
    }
}
