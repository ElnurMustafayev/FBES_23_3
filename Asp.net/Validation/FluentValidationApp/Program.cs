using System.Reflection;
using FluentValidation;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblies(new Assembly[] {
    Assembly.GetExecutingAssembly(),
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();