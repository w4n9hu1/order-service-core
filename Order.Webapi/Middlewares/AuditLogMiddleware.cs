using System.Globalization;
using System.Text;

namespace Order.Webapi.Middlewares
{
    public class AuditLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuditLogMiddleware> _logger;

        public AuditLogMiddleware(RequestDelegate next, ILogger<AuditLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("info one");

            await _next(context);

            _logger.LogInformation("info two");
        }
    }
}
