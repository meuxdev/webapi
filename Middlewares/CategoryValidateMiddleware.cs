
using System.Text.Json;
using webapi.Models;

namespace webapi
{
    public class CategoryValidateMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<CategoryValidateMiddleware> _logger;

        public CategoryValidateMiddleware(RequestDelegate next, ILogger<CategoryValidateMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var method = request.Method;
            var route = request.Path;

            if (method == "PUT" || method == "POST")
            {
                if (route.ToString().ToLower().Contains("task"))
                {
                    _logger.LogDebug("" + request.Body);
                }

            }
            await _next(context);
        }
    }



    public static class CategoryValidateMiddlewareExtension
    {

        public static IApplicationBuilder UseCategoryValidateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CategoryValidateMiddleware>();
        }
    }
}