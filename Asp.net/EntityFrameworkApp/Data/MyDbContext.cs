namespace EntityFrameworkApp.Data;

using EntityFrameworkApp.Entities;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}
}