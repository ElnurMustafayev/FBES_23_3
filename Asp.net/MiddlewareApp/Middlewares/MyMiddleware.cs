namespace MiddlewareApp.Middlewares;

public class MyMiddleware
{
    private readonly RequestDelegate next;
    public MyMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public Task InvokeAsync(HttpContext httpContext) {
        System.Console.WriteLine($"Start Request: {httpContext.TraceIdentifier}");
        this.next.Invoke(httpContext);
        System.Console.WriteLine($"End Request: {httpContext.TraceIdentifier}");

        return Task.CompletedTask;
    }
}