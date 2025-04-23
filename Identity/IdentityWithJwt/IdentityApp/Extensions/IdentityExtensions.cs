namespace IdentityApp.Extensions;

using IdentityApp.Data;
using IdentityApp.Defaults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public static class IdentityExtensions
{
    public static void InitAspnetIdentity(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<MyDbContext>(options =>
        {
            var connectinoString = configuration.GetConnectionString("IdentityDb");
            options.UseNpgsql(connectinoString);
        });

        serviceCollection.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>();
    }

    public async static Task SeedRolesAsync(this WebApplication app) {
        var scope = app.Services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await roleManager.CreateAsync(new IdentityRole(UserRoleDefaults.User));
        await roleManager.CreateAsync(new IdentityRole(UserRoleDefaults.Admin));
    }
}