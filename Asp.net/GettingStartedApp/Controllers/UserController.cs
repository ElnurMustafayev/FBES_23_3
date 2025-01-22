namespace GettingStartedApp.Controllers;

using GettingStartedApp.Models;
using Microsoft.AspNetCore.Mvc;

//[Route("/[controller]/[action]")]
[Route("/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public object CreateUser([FromBody]User newUser) {
        return new {
            Id = newUser.Id
        };
    }

    [HttpGet("{id}")]   // /user/123
    //[HttpGet("/{id}")]  // /123
    //[HttpGet("/[controller]/{id}")]
    //[Route("/[controller]/{id}")] // /user/123
    //[Route("/[controller]")] // /user?id=123
    //[Route("/[controller]/[action]")]
    //[Route("/[controller]/test/[action]")]
    //[Route("/[controller]/[action]")]
    public User GetUser(int id) {
        return new User {
            Id = id,
            Name = "Bob",
            Surname = "Marley"
        };
    }
}