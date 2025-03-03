using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityWithCookieApp.Models;
using IdentityWithCookieApp.EntityFramework;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

    [Authorize]
    public IActionResult MyInfo()
    {
        var user = new User {
            Id = int.Parse(base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value!),
            Name = base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value!,
            Surname = base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Surname)?.Value!,
            Mail = base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value!,
        };

        return base.View(user);

        /*
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
        */
    }

    [Authorize]
    public IActionResult Secret() {
        var roles = base.User.Claims
            .Where(claim => claim.Type == ClaimTypes.Role)
            .Select(claim => claim.Value);

        return Ok(roles);
    }
}
