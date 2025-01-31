namespace MvcApp.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        
        return base.View();
    }

    public IActionResult UserDetails()
    {
        return base.View(viewName: "User");
    }

    public IActionResult Privacy()
    {
        return base.View();
    }
}