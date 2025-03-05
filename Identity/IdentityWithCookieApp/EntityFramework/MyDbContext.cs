namespace IdentityWithCookieApp.EntityFramework;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    // public DbSet<User> Users { get; set; }
    // public DbSet<Role> Roles { get; set; }
    // public DbSet<UsersRoles> UsersRoles { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<UsersRoles>()
    //         .HasKey(ur => new { ur.UserId, ur.RoleId });

    //     base.OnModelCreating(modelBuilder);
    // }
}