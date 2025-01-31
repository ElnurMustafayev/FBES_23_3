var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();

app.UseRouting();


// /Test1/Test2 -> /Test1/Test2
// /Test1       -> /Test1/Index

// /Home/Index  -> /Home/Index
// /Home        -> /Home/Index
// /            -> /Home/Index

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
