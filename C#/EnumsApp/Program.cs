using EnumsApp;

var film = new Film("Very scary movie 3", FilmGenre.comedy)
{
    Rating = FilmRating.Excelent,
};

//if((int)film.Rating >= 3)
if(film.Rating >= FilmRating.Medium)
{
    Console.WriteLine("Film is OK!");
}

switch (film.Genre)
{
    case FilmGenre.comedy:
        Console.WriteLine("HAHAHA");
        break;
    case FilmGenre.drama:
        Console.WriteLine("omg...");
        break;
    case FilmGenre.detective:
        Console.WriteLine("hmmm...");
        break;
    default:
        throw new NotImplementedException($"{film.Genre} genre has no implementation!");
}

/*
foreach (var filmGenreName in Enum.GetNames<FilmGenre>())
{
    Console.WriteLine(filmGenreName);
}

foreach (var filmGenreName in Enum.GetValues<FilmGenre>())
{
    Console.WriteLine($"{filmGenreName}: {(int)filmGenreName}");
}
*/