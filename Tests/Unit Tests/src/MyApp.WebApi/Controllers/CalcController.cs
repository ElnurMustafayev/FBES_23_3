namespace MyApp.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using MyApp.WebApi.Services.Base;

[Route("/api/[controller]")]
public class CalcController : ControllerBase
{
    private readonly ICalcService calcService;
    public CalcController(ICalcService calcService)
    {
        this.calcService = calcService;
    }
    
    [HttpPost("[action]/{num1}/{num2}")]
    public ActionResult<decimal> Plus(decimal num1, decimal num2) {
        var result = this.calcService.Sum(num1, num2);

        return base.Ok(result);
    }
}