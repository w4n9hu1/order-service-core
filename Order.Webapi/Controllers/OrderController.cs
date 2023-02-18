using Microsoft.AspNetCore.Mvc;

namespace Order.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
