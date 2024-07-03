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

/*
void GetFilmInfo1(string name, FilmRating rating)
{
    if (rating == FilmRating.Excelent)
    {
        // ...
    }
}

void GetFilmInfo2(string name, int rating)
{
    if (rating == 5)
    {
        // ...
    }
}

int filmRating2 = FilmRatingConstants.Excelent;
FilmRating filmRating1 = FilmRating.Excelent;
GetFilmInfo1("test", filmRating1);
*/


/*
var consoleKeyInfo = Console.ReadKey();
ConsoleKey key = consoleKeyInfo.Key;

if(key == ConsoleKey.F22)
{
    //... 
}
*/