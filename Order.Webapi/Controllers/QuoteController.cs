using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Application;

namespace Order.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuotesApi _quotesApi;

        public QuoteController(IQuotesApi quotesApi)
        {
            _quotesApi = quotesApi;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new JsonResult(await _quotesApi.GetQuote());
        }
    }
}

