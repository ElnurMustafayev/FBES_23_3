namespace IdentityWithCookieApp.Controllers;

using System.Security.Claims;
using IdentityWithCookieApp.Dtos;
using IdentityWithCookieApp.EntityFramework;
using IdentityWithCookieApp.Enums;
using IdentityWithCookieApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class IdentityController : Controller
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly MyDbContext dbContext;
    //private readonly IDataProtector dataProtector;

    public IdentityController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        //IDataProtectionProvider dataProtectionProvider,
        MyDbContext dbContext
        )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
        this.dbContext = dbContext;
        //this.dataProtector = dataProtectionProvider.CreateProtector("Identity");
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
            var user = new IdentityUser {
                UserName = newUser.Name,
                Email = newUser.Mail,
            };
            await this.userManager.CreateAsync(user, newUser.Password!);

            await this.userManager.AddToRolesAsync(user, new List<string> {"Admin", "User"});

            //await dbContext.Users.AddAsync(newUser);
            //await dbContext.SaveChangesAsync();

            //await dbContext.UsersRoles.AddAsync(new UsersRoles {
            //    UserId = newUser.Id,
            //    RoleId = (int)Roles.User
            //});

            //await dbContext.SaveChangesAsync();
        }
        catch(Exception) {
            base.TempData["Error"] = "Something went wrong...";
            return base.RedirectToAction(nameof(Registration));
        }

        return base.RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public ActionResult Login(string? returnUrl) {
        var errorMessage = base.TempData["Error"];

        if(string.IsNullOrWhiteSpace(returnUrl) == false) {
            base.ViewData["returnUrl"] = returnUrl;
        }

        if(errorMessage != null) {
            base.ModelState.AddModelError("All", errorMessage.ToString()!);
        }

        return base.View();
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromForm] LoginDto dto) {
        var foundUser = await this.userManager.FindByEmailAsync(dto.Login);
        await signInManager.PasswordSignInAsync(foundUser!, dto.Password, true, false);

        //var foundUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Mail == dto.Login && u.Password == dto.Password);

        //if(foundUser == null) {
        //    base.TempData["Error"] = "Incorrect login or password";
        //    return base.RedirectToAction(nameof(Login), new {
        //        ReturnUrl = dto.ReturnUrl
        //    });
        //}

        //var roleNames = await this.dbContext.UsersRoles.Where(ur => ur.UserId == foundUser.Id)
        //    .Select(ur => ur.Role.Name)
        //    .ToListAsync();
        //
        //var claims = new List<Claim>() {
        //    new Claim(ClaimTypes.NameIdentifier, foundUser.Id.ToString()),
        //    new Claim(ClaimTypes.Name, foundUser.Name),
        //    new Claim(ClaimTypes.Surname, foundUser.Surname),
        //    new Claim(ClaimTypes.Email, foundUser.Mail),
        //    //new Claim(ClaimTypes.Country, "Az"),
        //    //new Claim(ClaimTypes.Gender, "Male"),
        //};
        //claims.AddRange(roleNames.Select(roleName => new Claim(ClaimTypes.Role, roleName)));

        //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //
        //await base.HttpContext.SignInAsync(
        //    scheme: CookieAuthenticationDefaults.AuthenticationScheme, 
        //    principal: claimsPrincipal);

        if(string.IsNullOrWhiteSpace(dto.ReturnUrl) == false) {
            return base.Redirect(dto.ReturnUrl);
        }

        return base.RedirectToAction(actionName: "Index", controllerName: "Home");

        /*
        var foundUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Mail == dto.Login && u.Password == dto.Password);

        if(foundUser == null) {
            base.TempData["Error"] = "Incorrect login or password";
            return base.RedirectToAction(nameof(Login));
        }

        string idHash = dataProtector.Protect(foundUser.Id.ToString());

        base.HttpContext.Response.Cookies.Append("Identity", idHash);

        return base.RedirectToAction(actionName: "Index", controllerName: "Home");
        */
    }

    [HttpGet]
    public async Task<ActionResult> Logout([FromForm] LoginDto dto) {
        await base.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        /*
        base.HttpContext.Response.Cookies.Delete("Identity");
        */

        return base.RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}