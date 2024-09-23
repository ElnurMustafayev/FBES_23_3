namespace ParallelApp;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public override string ToString()
    {
        return $"{Id}: {Name} {Surname}";
    }
}