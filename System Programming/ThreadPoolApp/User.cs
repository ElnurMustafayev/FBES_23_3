namespace ThreadPoolApp;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public User()
    {
        this.Name = "UNKNOWN";
        this.Surname = "UNKNOWN";
    }

    public override string ToString()
    {
        return $"{Id}: {Name} {Surname}";
    }
}