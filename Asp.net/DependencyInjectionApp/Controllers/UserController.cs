namespace DependencyInjectionApp.Controllers;

using DependencyInjectionApp.Models;
using DependencyInjectionApp.Repositories;
using Microsoft.AspNetCore.Mvc;

// public class ElnurResult : ActionResult {
//     public override void ExecuteResult(ActionContext context)
//     {
//         context.HttpContext.Response.StatusCode = 777;
//         base.ExecuteResult(context);
//     }
// }

[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private UserRepository userRepository;

    public UserController()
    {
        this.userRepository = new UserRepository();
    }

    [HttpPost]
    public void CreateUser([FromBody]User user) {
        userRepository.CreateUser(user);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<User> GetUserById(int id) {
        var foundUser = userRepository.GetUserById(id);
        // var statusCode = foundUser != null 
        //     ? HttpStatusCode.OK 
        //     : HttpStatusCode.NotFound;

        // base.HttpContext.Response.StatusCode = (int)statusCode;

        if(foundUser == null) {
            return base.NotFound();
        }

        return base.Ok(foundUser);
    }
}