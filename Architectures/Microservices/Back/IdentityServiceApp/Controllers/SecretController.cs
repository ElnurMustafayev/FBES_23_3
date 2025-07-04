namespace IdentityServiceApp.Controllers;

using System.Security.Claims;
using IdentityServiceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("/api/[controller]/[action]")]
public class SecretController : ControllerBase
{
    [HttpGet]
    public string Code()
    {
        return "verysecretcode";
    }

    [HttpGet]
    [Authorize(Roles = UserRoleDefaults.User)]
    public string Role()
    {
        return base.User.Claims.First(c => c.Type == ClaimTypes.Role).Value;
    }
    
    [HttpGet]
    [Authorize(Roles = UserRoleDefaults.Admin)]
    public string ForAdmin() {
        return "Hello, Admin!!!";
    }
}