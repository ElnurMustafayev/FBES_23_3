namespace MyApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using MyApp.Core.Models;
using MyApp.Core.Services;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ITestService testService;

    public TestController(ITestService testService)
    {
        this.testService = testService;
    }
    
    [HttpPost]
    public ActionResult Call(Person person) {
        testService.Test(person);

        return base.Ok();
    }
}