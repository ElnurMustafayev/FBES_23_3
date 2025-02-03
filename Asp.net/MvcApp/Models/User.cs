namespace MvcApp.Models;

public class User
{
    private static int idCounter = 1;
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }

    public User()
    {
        this.Id = idCounter++;
    }
}