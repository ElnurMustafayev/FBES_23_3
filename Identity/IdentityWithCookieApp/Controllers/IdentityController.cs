namespace IdentityWithCookieApp.Controllers;

using IdentityWithCookieApp.Dtos;
using IdentityWithCookieApp.EntityFramework;
using IdentityWithCookieApp.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class IdentityController : Controller
{
    private readonly MyDbContext dbContext;
    private readonly IDataProtector dataProtector;

    public IdentityController(MyDbContext dbContext, IDataProtectionProvider dataProtectionProvider)
    {
        this.dbContext = dbContext;
        this.dataProtector = dataProtectionProvider.CreateProtector("Identity");
    }

    [HttpGet]
    public ActionResult Registration() {
        var errorMessage = base.TempData["Error"];

        if(errorMessage != null) {
            base.ModelState.AddModelError("All", errorMessage.ToString()!);
        }

        return base.View();
    }

    [HttpPost]
    public async Task<ActionResult> Registration([FromForm] User newUser) {
        try {
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
        }
        catch(Exception) {
            base.TempData["Error"] = "Something went wrong...";
            return base.RedirectToAction(nameof(Registration));
        }

        return base.RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public ActionResult Login() {
        var errorMessage = base.TempData["Error"];

        if(errorMessage != null) {
            base.ModelState.AddModelError("All", errorMessage.ToString()!);
        }

        return base.View();
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromForm] LoginDto dto) {
        var foundUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Mail == dto.Login && u.Password == dto.Password);

        if(foundUser == null) {
            base.TempData["Error"] = "Incorrect login or password";
            return base.RedirectToAction(nameof(Login));
        }

        string idHash = dataProtector.Protect(foundUser.Id.ToString());

        base.HttpContext.Response.Cookies.Append("Identity", idHash);

        return base.RedirectToAction(actionName: "Index", controllerName: "Home");
    }

    [HttpGet]
    public ActionResult Logout([FromForm] LoginDto dto) {
        base.HttpContext.Response.Cookies.Delete("Identity");

        return base.RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}