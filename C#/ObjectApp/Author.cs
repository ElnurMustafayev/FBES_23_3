namespace ObjectApp;

class Author
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Fullname => $"{this.Name} {this.Surname}";

    public Book WriteBook()
    {
        return new Book(
            author: this,
            pagesCount: Random.Shared.Next(100, 500),
            title: $"{this.Fullname}'s Book"
        );
    }

    public Author(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
    }

    public override string ToString()
    {
        return this.Fullname;
    }
}
