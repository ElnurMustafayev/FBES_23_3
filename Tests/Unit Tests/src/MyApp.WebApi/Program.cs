using System.Reflection;
using FluentValidation;
using MyApp.WebApi.Repositories;
using MyApp.WebApi.Repositories.Base;
using MyApp.WebApi.Services;
using MyApp.WebApi.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICalcService, CalcService>();
builder.Services.AddScoped<IUserRepository, UserSqlRepository>((sp) => {
    var connectionString = builder.Configuration.GetConnectionString("UsersDb") ?? throw new Exception("ConnectionString not found!");
    return new UserSqlRepository(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(configuration => {
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();