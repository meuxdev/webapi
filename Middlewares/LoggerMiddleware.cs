public class LoggerMiddleware
{

    private readonly RequestDelegate _next;
    private readonly ILogger<LoggerMiddleware> _logger;

    public LoggerMiddleware(ILogger<LoggerMiddleware> logger,RequestDelegate nextRequest)
    {
        _next = nextRequest;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);
        // middleware actions
        string loggerMsg = "✔️ {0,6} | {1,30} | {2,5} | {3,10} | {4,10} ";
        _logger.LogDebug(String.Format(loggerMsg, 
                                        context.Request.Method,
                                        context.Request.Path,
                                        context.Response.StatusCode,
                                        DateTime.Now.ToShortDateString(), 
                                        DateTime.Now.ToShortTimeString()));
    }
}


public static class LoggerMiddlewareExtension
{
    public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggerMiddleware>();
    }
}