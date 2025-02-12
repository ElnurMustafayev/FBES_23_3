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
    private readonly IHttpLogger logger;

    public TestController(ITestService testService, IHttpLogger logger)
    {
        this.logger = logger;
        this.testService = testService;
    }

    [HttpGet]
    public async Task<ActionResult> Method(string? text) {
        this.testService.DontPutNull(text);
        await this.testService.GoToDatabaseAsync();
        this.testService.NeverCrashes();

        return base.Ok();
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> Call(string? text) {
        throw new DivideByZeroException();
    }
}