namespace Cqrs.WebApi.Models;

public class User
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public string? Email { get; set; }
}