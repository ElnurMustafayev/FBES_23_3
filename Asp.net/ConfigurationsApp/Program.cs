using ConfigurationsApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ProductSqlRepository>((serviceProvider) => {
    //var connectionString = builder.Configuration["ConnectionStrings:SqlDb"];
    var connectionString = builder.Configuration.GetConnectionString("SqlDb");

    return new ProductSqlRepository(connectionString);
});

// var configurationValueStr = builder.Configuration["MyKey"];
// System.Console.WriteLine(configurationValueStr);

// var configurationValueStr = builder.Configuration["MyComplexKey:MyKey"];
// System.Console.WriteLine(configurationValueStr);

// var configurationValueStr = builder.Configuration["ButtonOptions:Animation"];
// System.Console.WriteLine(configurationValueStr);

// var buttonOptions = new ButtonOptions {
//     Text = builder.Configuration["ButtonOptions:Text"],
//     Animation = bool.Parse(builder.Configuration["ButtonOptions:Animation"]),
//     FontSize = int.Parse(builder.Configuration["ButtonOptions:FontSize"]),
// };
//System.Console.WriteLine(buttonOptions);

// var loggingLevelDefaultStr = builder.Configuration
//     .GetSection("Logging")
//     .GetSection("LogLevel")
//     .GetSection("Default")
//     .Get<string>();
// System.Console.WriteLine(loggingLevelDefaultStr);

// var buttonOptions = builder.Configuration
//     .GetSection("ButtonOptions")
//     .Get<ButtonOptions>();

// System.Console.WriteLine(buttonOptions);

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();