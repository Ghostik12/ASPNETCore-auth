namespace AuthenticationService.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;

        public LogMiddleware(RequestDelegate requestDelegate, ILogger logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke (HttpContext context)
        {
            _logger.WriteEvent("Я твой Middleware");
            _logger.WriteEvent($"{context.Connection.RemoteIpAddress}");
            await _requestDelegate(context);
        }
    }

    public static class LogMiddlewareExtnsions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}
