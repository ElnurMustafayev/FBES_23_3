namespace IdentityWithCookieApp.Models;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Mail { get; set; }
    public string? Password { get; set; }
}