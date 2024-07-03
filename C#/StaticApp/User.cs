namespace StaticApp;

public class User
{
    public readonly UserId UserId;
    public string? Name { get; set; }

    public readonly DateTime CreationDate;

    public User()
    {
        this.UserId = new UserId();
        this.CreationDate = DateTime.Now;
    }

    public User(string name) : this()
    {
        this.Name = name;
    }
}