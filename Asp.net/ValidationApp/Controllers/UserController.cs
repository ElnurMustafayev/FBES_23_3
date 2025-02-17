namespace ValidationApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using ValidationApp.Models;

public class UserController : Controller
{
    [HttpGet]
    public ActionResult Index() {
        return base.View();
    }

    [HttpGet]
    public ActionResult Create() {
        return base.View();
    }

    [HttpPost("/[controller]")]
    [ActionName("CreateNewUser")]
    public ActionResult Create([FromForm]User user) {
        if(base.ModelState.IsValid == false) {
            return base.RedirectToAction(nameof(Create), "User");
        }

        return base.RedirectToAction(nameof(Index), "User");
    }
}