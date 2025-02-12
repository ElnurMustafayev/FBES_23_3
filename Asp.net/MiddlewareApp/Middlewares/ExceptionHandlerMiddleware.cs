namespace MiddlewareApp.Middlewares;

using System.Net;
using MiddlewareApp.Responses;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext) {
        try {
            await this.next.Invoke(httpContext);
        }
        catch(ArgumentNullException ex) {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new BadRequestResponse(message: ex.Message) {
                Parameter = ex.ParamName
            });

            httpContext.Items["exception"] = ex.ToString();
        }
        catch(Exception ex) {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new InternalServerErrorResponse(message: "Internal server error"));
            
            httpContext.Items["exception"] = ex.ToString();
        }
    }
}