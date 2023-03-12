namespace Order.Webapi.Middlewares
{
    public static class OrderMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuditLog(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuditLogMiddleware>();
        }
    }
}
