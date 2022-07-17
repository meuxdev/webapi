public class LoggerMiddleware
{

    private readonly RequestDelegate _next;


    public LoggerMiddleware(RequestDelegate nextRequest)
    {
        _next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);
        // middleware actions
        string loggerMsg = "✔️ {0,6} | {1,30} | {2,5} | {3,10} | {4,10} ";
        Console.WriteLine(String.Format(loggerMsg, 
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