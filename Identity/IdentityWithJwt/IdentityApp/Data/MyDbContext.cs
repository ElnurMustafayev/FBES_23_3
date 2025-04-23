namespace IdentityApp.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public MyDbContext(DbContextOptions options) : base(options) {}
}