namespace IdentityApp.Dtos;

public class RegistrationDto
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}