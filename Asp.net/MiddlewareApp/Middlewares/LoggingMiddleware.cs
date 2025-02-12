using MiddlewareApp.Services.Base;

namespace MiddlewareApp.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate next;
    public LoggingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IHttpLogger logger) {
        await this.next.Invoke(httpContext);
        
        var message = httpContext.Items["exception"];

        await logger.LogAsync(httpContext, message?.ToString());
    }
}