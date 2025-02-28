using IdentityWithCookieApp.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("IdentityDb");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDataProtection();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
