using WebApiApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ProductPostgresRepository>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("ProductDb");
    ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionString);

    return new ProductPostgresRepository(connectionString);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();