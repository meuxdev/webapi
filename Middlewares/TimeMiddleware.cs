public class TimeMiddleware
{
    private readonly RequestDelegate _next; // invoke next middleware

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        _next = nextRequest; // assign the next middleware.
    }


    public async Task Invoke(HttpContext context) // receives the http context
    {
        // await _next(context);
        // Check the param time.
        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }

        if(!context.Response.HasStarted) // validate that the response has not started.
        {
            await _next(context); // invoke next middleware.
        }
    }



}

// Class to Implement the middleware
public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }


}