namespace DependencyInjectionApp.Controllers;

using DependencyInjectionApp.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

[Route("/[controller]/[action]")]
public class TestController : ControllerBase
{
    private readonly ICarRepository carRepository;

    public TestController(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    [HttpDelete]
    public ActionResult BreakCar() {
        this.carRepository.BreakCar();

        return Ok();
    }
}