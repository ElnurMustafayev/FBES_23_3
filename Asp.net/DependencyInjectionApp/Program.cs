using DependencyInjectionApp.Controllers;
using DependencyInjectionApp.Repositories;
using DependencyInjectionApp.Repositories.Base;
using DependencyInjectionApp.Services;
using DependencyInjectionApp.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// создание 1 объекта на всё приложение
//builder.Services.AddSingleton<IUserRepository, UserWithValidationRepository>();

// создание 1 объекта на 1 запрос
//builder.Services.AddScoped<IUserRepository, UserWithValidationRepository>();

// создание n объектов на n инъекций 
//builder.Services.AddTransient<IUserRepository, UserRepository>();

// builder.Services.Add(
//     new ServiceDescriptor(
//         typeof(IUserRepository), 
//         typeof(UserSqlRepository),
//         ServiceLifetime.Transient));

builder.Services.AddScoped<IUserService>((serviceProvider) => { 
    var userRepository = serviceProvider.GetRequiredService<IUserRepository>();

    return new UserService(userRepository);
});

builder.Services.AddTransient<IUserRepository>((serviceProvider) => {
    System.Console.WriteLine("LAMBDA");
    if(Random.Shared.Next(3) == 1) 
        return new UserSqlRepository("test");
    else
        return new UserRepository();
});

// Type[] repoTypes = {
//     typeof(UserSqlRepository),
//     typeof(UserRepository),
//     typeof(UserWithValidationRepository),
// };
// builder.Services.AddScoped(
//     typeof(IUserRepository), 
//     repoTypes.ElementAt(Random.Shared.Next(repoTypes.Length)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();

/*

ICarRepository

CarGoodRepository   -> works
CarBadRepository    -> throws exception

Необходимо задать такое поведение (логика должна быть не в контроллере), 
чтобы каждый второй раз инджектился объект типа данных CarBadRepository

*/