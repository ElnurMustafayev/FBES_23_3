var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();




/* 1

GetBookByAuthor
CreateBook

+ repository
(Storage: RAM (List<Book>))

*/

/* 2

Написать необходимую валидацию для CreateBook endpoint-а

for example:
book.PagesCount <= 0 -> base.BadRequest

Contract for 400:
{
    "Property": "PagesCount",
    "Message": "Count of pages can not be equal or less than 0!"
}

*/