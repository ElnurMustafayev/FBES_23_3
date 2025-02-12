using MiddlewareApp.Middlewares;
using MiddlewareApp.Options;
using MiddlewareApp.Repositories;
using MiddlewareApp.Repositories.Base;
using MiddlewareApp.Services;
using MiddlewareApp.Services.Base;

// TODO: default exceptions handling

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IHttpLogRepository, HttpLogSqlRepository>();
builder.Services.AddScoped<IHttpLogger, HttpLogger>();

builder.Services.Configure<DatabaseOptions>(options => {
    var connectionString = builder.Configuration.GetConnectionString("MyDatabase");

    options.ConnectionString = connectionString!;
});

builder.Services.AddScoped<ITestService, TestService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();