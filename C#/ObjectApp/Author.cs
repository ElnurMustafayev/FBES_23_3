namespace ObjectApp;

class Author
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Author(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
    }
}
