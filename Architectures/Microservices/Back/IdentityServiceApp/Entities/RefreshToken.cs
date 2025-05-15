namespace IdentityServiceApp.Entities;

public class RefreshToken
{
    public Guid Token { get; set; }
    public required string UserId { get; set; }
}