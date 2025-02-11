using MiddlewareApp.Middlewares;
using MiddlewareApp.Options;
using MiddlewareApp.Services;
using MiddlewareApp.Services.Base;

// TODO: add logging
// TODO: default exceptions handling

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.Configure<DatabaseOptions>(options => {
    var connectionString = builder.Configuration.GetConnectionString("MyDatabase");

    options.ConnectionString = connectionString!;
});

builder.Services.AddScoped<ITestService, TestService>();

var app = builder.Build();

app.UseMiddleware<MyMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();