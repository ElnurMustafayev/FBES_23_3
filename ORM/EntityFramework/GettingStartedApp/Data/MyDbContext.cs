namespace GettingStartedApp.Data;

using GettingStartedApp.Entities;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    private const string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;TrustServerCertificate=True;";
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}