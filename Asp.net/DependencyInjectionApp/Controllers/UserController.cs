namespace DependencyInjectionApp.Controllers;

using System.Net;
using DependencyInjectionApp.Exceptions;
using DependencyInjectionApp.Models;
using DependencyInjectionApp.Repositories.Base;
using DependencyInjectionApp.Services.Base;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ProducesResponseType(400, Type = typeof(List<ValidationResponse>))]
[ProducesResponseType(500)]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService, IUserRepository userRepository, IServiceProvider serviceProvider)
    {
        this.userService = userService;
        System.Console.WriteLine($"CTOR: {nameof(UserController)} {this.GetHashCode()} {userRepository.GetHashCode()}");
    }

    [HttpPost]
    [ProducesResponseType(200)]
    public ActionResult CreateUser([FromBody]User user) {
        try {
            //this.userService.SignUp(user);

            return base.Ok();
        }
        catch(ValidationException validationException) {
            return base.BadRequest(validationException.validationResponseItems);
        }
        catch(Exception) {
            return base.StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200, Type = typeof(User))]
    public ActionResult<User> GetUserById(int id) {
        return Ok();
        // var foundUser = userRepository.GetUserById(id);
        // // var statusCode = foundUser != null 
        // //     ? HttpStatusCode.OK 
        // //     : HttpStatusCode.NotFound;

        // // base.HttpContext.Response.StatusCode = (int)statusCode;

        // if(foundUser == null) {
        //     return base.NotFound();
        // }

        // return base.Ok(foundUser);
    }
}