namespace MiddlewareApp.Services.Base;

public interface IHttpLogger
{
    public Task LogAsync(HttpContext context, string? message = null);
}