using IdentityApp.Defaults;
using IdentityApp.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.InitAspnetIdentity(builder.Configuration);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

await app.SeedRolesAsync();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();