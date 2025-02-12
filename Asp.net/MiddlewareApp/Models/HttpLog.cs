namespace MiddlewareApp.Models;

using System.Net;

public class HttpLog
{
    public int Id { get; set; } = 0;
    public string RequestId { get; set; }
    public string RequestUrl { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }

    public HttpLog(string requestId, string requestUrl, HttpStatusCode statusCode)
    {
        this.RequestId = requestId;
        this.RequestUrl = requestUrl;
        this.StatusCode = statusCode;
    }

    public HttpLog()
    {
        this.RequestId = string.Empty;
        this.RequestUrl = string.Empty;
        this.StatusCode = HttpStatusCode.OK;
    }
}