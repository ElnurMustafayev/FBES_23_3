namespace MvcApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.Repositories.Base;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository userRepository;

    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
    [HttpGet]
    public IActionResult Index() {
        return View();
    }

    [HttpPost]
    public IActionResult AddUser([FromForm]User user) {
        this.userRepository.InsertUser(user);

        return base.RedirectToAction("Index");

        //return base.View(viewName: "Index");
    }

    [Route("{id:int}")]
    [HttpPut]
    public IActionResult UpdateUser(int id, [FromBody] User changedUser) {
        bool changed = this.userRepository.UpdateUser(id, changedUser);

        return base.Ok();
    }

    [Route("{id:int}")]
    [HttpGet]
    public IActionResult GetUserById(int id)
    {
        //base.ViewBag.IdToSearch = id

        /*
        var endpointUrl = $"http://localhost:7000/api/User/{id}";
        HttpClient httpClient = new HttpClient();

        var httpResponse = await httpClient.GetAsync(endpointUrl);

        if(httpResponse.IsSuccessStatusCode) {
            var foundUser = await httpResponse.Content.ReadFromJsonAsync<User>();

            if(foundUser == null) {
                return base.View(viewName: "UserInfo", model: null);
            }

            return base.View(viewName: "UserInfo", model: foundUser);
        }

        return base.View(viewName: "UserInfo", model: null);
        */

        var foundUser = this.userRepository.GetUserById(id);

        if(foundUser == null) {
            return base.View(viewName: "UserInfo", model: null);
        }

        return base.View(viewName: "UserInfo", model: foundUser);
    }
}