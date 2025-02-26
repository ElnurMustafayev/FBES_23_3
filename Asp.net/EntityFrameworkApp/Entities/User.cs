namespace EntityFrameworkApp.Entities;

public class User
{
    public int Id { get; set; }
    public string? Mail { get; set; }
    public required string Name { get; set; }
}