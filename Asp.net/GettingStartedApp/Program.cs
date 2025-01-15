// asp.net web api
// add 1 get endpoint returning object

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/user", () =>
{
    return new {
        Name = "Bob",
        Surname = "Marley"
    };
});

app.Run();