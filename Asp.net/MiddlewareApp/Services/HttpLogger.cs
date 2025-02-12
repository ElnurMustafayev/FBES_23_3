using System.Net;
using MiddlewareApp.Models;
using MiddlewareApp.Repositories.Base;
using MiddlewareApp.Services.Base;

namespace MiddlewareApp.Services;

public class HttpLogger : IHttpLogger
{
    private readonly IHttpLogRepository repository;

    public HttpLogger(IHttpLogRepository repository)
    {
        this.repository = repository;
    }

    public async Task LogAsync(HttpContext context, string? message = null)
    {
        var log = new HttpLog() {
            RequestId = context.TraceIdentifier,
            RequestUrl = context.Request.Path,
            StatusCode = (HttpStatusCode)context.Response.StatusCode,
            Message = message
        };

        await this.repository.InsertAsync(log);
    }
}