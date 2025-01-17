namespace GettingStartedApp.Controllers;

using Microsoft.AspNetCore.Mvc;

public class UserController : ControllerBase
{
    [HttpPost]
    [Route("/user/create")]
    public object CreateUser(string name, string surname) {
        return new {
            Id = Guid.NewGuid()
        };
    }

    [HttpGet]
    [Route("/user/get")]
    public object GetUser(Guid id) {
        return new {
            Id = id,
            Name = "Bob",
            Surname = "Marley"
        };
    }
}