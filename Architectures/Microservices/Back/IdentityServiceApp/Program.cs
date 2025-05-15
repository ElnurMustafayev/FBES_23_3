using IdentityServiceApp.Extensions;
using IdentityServiceApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitAspnetIdentity(builder.Configuration);
builder.Services.InitAuth(builder.Configuration);
builder.Services.InitSwagger();
builder.Services.InitCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();

var app = builder.Build();

var scope = app.Services.CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
await roleManager.CreateAsync(new IdentityRole(UserRoleDefaults.User));
await roleManager.CreateAsync(new IdentityRole(UserRoleDefaults.Admin));

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("BlazorApp");

app.Run();