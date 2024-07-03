namespace ObjectApp;

class Book
{
    public string Title { get; set; }
    public Author Author { get; set; }
    public int PagesCount { get; set; }

    public Book(string title, Author author, int pagesCount)
    {
        this.Title = title;
        this.Author = author;
        this.PagesCount = pagesCount;
    }

    public override string ToString() => @$"Book: {this.Title}
Author: {this.Author.Name} {this.Author.Surname}
{this.PagesCount}";

    public void PrintInfo()
    {
        Console.WriteLine($"Book: {this.Title}");
        Console.WriteLine($"Author: {this.Author.Name} {this.Author.Surname}");
        Console.WriteLine($"{this.PagesCount} pages");
    }
}