namespace IdentityWithCookieApp.Dtos;

public class LoginDto
{
    public string? ReturnUrl { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}