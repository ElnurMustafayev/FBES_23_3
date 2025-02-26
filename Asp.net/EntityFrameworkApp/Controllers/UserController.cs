namespace EntityFrameworkApp.Controllers;

using EntityFrameworkApp.Data;
using EntityFrameworkApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly MyDbContext dbContext;

    public UserController(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();

        return base.Ok(new
        {
            Id = user.Id
        });
    }

    [HttpGet("All")]
    public async Task<ActionResult<int>> GetAllUsersAsync()
    {
        var allUsers = await dbContext.Users.ToListAsync();

        return base.Ok(allUsers);
    }
}