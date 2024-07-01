namespace EnumsApp;

public class Film
{
    // authorName: string, comment: string, rating: FilmRating
    //public Rating[] Ratings { get; set; }

    //public double Rating => {
    //    // avg(Ratings)
    //}

    public FilmRating Rating { get; set; }

    public readonly string Name;
    public readonly FilmGenre Genre;

    public Film(string name, FilmGenre genre)
    {
        this.Name = name;
        this.Genre = genre;
    }
}