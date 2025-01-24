using DependencyInjectionApp.Repositories;
using DependencyInjectionApp.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// создание 1 объекта на всё приложение
//builder.Services.AddSingleton<IUserRepository, UserWithValidationRepository>();

// создание 1 объекта на 1 запрос
//builder.Services.AddScoped<IUserRepository, UserWithValidationRepository>();

// создание n объектов на n инъекций 
builder.Services.AddTransient<IUserRepository, UserWithValidationRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();