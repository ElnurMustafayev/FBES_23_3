using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityWithCookieApp.Models;
using IdentityWithCookieApp.EntityFramework;
using Microsoft.AspNetCore.DataProtection;

namespace IdentityWithCookieApp.Controllers;

public class HomeController : Controller
{
    private readonly MyDbContext dbContext;
    private readonly IDataProtector dataProtector;
    public HomeController(MyDbContext dbContext, IDataProtectionProvider dataProtectionProvider)
    {
        this.dbContext = dbContext;
        this.dataProtector = dataProtectionProvider.CreateProtector("Identity");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    public IActionResult MyInfo()
    {
        var identityCookieValueHash = base.HttpContext.Request.Cookies["Identity"];

        if(string.IsNullOrWhiteSpace(identityCookieValueHash)) {
            return base.RedirectToAction("Login", "Identity");
        }

        var identityCookieValue = dataProtector.Unprotect(identityCookieValueHash);

        if(int.TryParse(identityCookieValue, out int userId)) {
            var foundUser = this.dbContext.Users.FirstOrDefault(u => u.Id == userId);

            if(foundUser == null) {
                base.HttpContext.Response.Cookies.Delete("Identity");
                return base.RedirectToAction("Login", "Identity");
            }

            return base.View(foundUser);
        }

        base.HttpContext.Response.Cookies.Delete("Identity");
        return base.RedirectToAction("Login", "Identity");
    }
}
