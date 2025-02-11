namespace MiddlewareApp.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using MiddlewareApp.Responses;
using MiddlewareApp.Services.Base;

[Route("/api/[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(InternalServerErrorResponse))]
[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestResponse))]
[ProducesResponseType((int)HttpStatusCode.OK)]
public class TestController : ControllerBase
{
    private readonly ITestService testService;

    public TestController(ITestService testService)
    {
        this.testService = testService;
    }

    [HttpGet]
    public async Task<ActionResult> Method(string? text) {
        try {
            this.testService.DontPutNull(text);
            await this.testService.GoToDatabaseAsync();
            this.testService.NeverCrashes();

            return base.Ok();
        }
        catch(ArgumentNullException ex) {
            return base.StatusCode(
                (int)HttpStatusCode.BadRequest,
                new BadRequestResponse(message: ex.Message) {
                    Parameter = ex.ParamName
                });
        }
        catch(Exception) {
            return base.StatusCode(
                (int)HttpStatusCode.InternalServerError,
                new InternalServerErrorResponse(message: "Internal server error"));
        }
    }
}