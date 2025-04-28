namespace IdentityApp.Controllers;

using IdentityApp.Defaults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class SecretController : ControllerBase
{
    [Authorize(Roles = UserRoleDefaults.Admin)]
    [HttpGet]
    public ActionResult ForAdmin() {
        return Ok("Admin's secret!");
    }

    [Authorize(Roles = UserRoleDefaults.User)]
    [HttpGet]
    public ActionResult ForUser() {
        return Ok("User's secret!");
    }
}