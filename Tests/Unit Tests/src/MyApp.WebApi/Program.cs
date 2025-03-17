using MyApp.WebApi.Services;
using MyApp.WebApi.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICalcService, CalcService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();