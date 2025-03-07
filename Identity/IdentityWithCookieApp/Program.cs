using System.Security.Claims;
using IdentityWithCookieApp.EntityFramework;
using IdentityWithCookieApp.Enums;
using IdentityWithCookieApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("IdentityDb");
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {})
    .AddEntityFrameworkStores<MyDbContext>();

builder.Services.AddDataProtection();


builder.Services.AddAuthentication(defaultScheme: CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
        authenticationScheme: CookieAuthenticationDefaults.AuthenticationScheme,
        configureOptions: options =>
        {
            options.LoginPath = "/Identity/Login";
        });


builder.Services.AddAuthorization(options => {
    options.AddPolicy(
        name: "MyPolicy",
        configurePolicy: policyBuilder => {
            policyBuilder
                .RequireRole("Admin")
                .RequireClaim(ClaimTypes.Name, "Bob", "Ann", "John", "Elnur")
                .RequireRole("User");
        }
    );
});

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

await roleManager.CreateAsync(new IdentityRole {Name = "Admin"});
await roleManager.CreateAsync(new IdentityRole {Name = "User"});

/*
var serviceScope = app.Services.CreateScope();
var dbContext = serviceScope.ServiceProvider.GetRequiredService<MyDbContext>();

var adminRole = await dbContext.Roles.FirstOrDefaultAsync(role => role.Name == nameof(Roles.Admin));
if(adminRole == null) {
    System.Console.WriteLine($"Role '{nameof(Roles.Admin)}' created...");
    await dbContext.Roles.AddAsync(new Role { Name = nameof(Roles.Admin)});
}

var userRole = await dbContext.Roles.FirstOrDefaultAsync(role => role.Name == nameof(Roles.User));
if(userRole == null) {
    System.Console.WriteLine($"Role '{nameof(Roles.User)}' created...");
    await dbContext.Roles.AddAsync(new Role { Name = nameof(Roles.User)});
}

await dbContext.SaveChangesAsync();
*/

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
