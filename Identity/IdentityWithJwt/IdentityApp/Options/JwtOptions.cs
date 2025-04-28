namespace IdentityApp.Options;

public class JwtOptions
{
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required long LifetimeInMinutes { get; set; }
    public required string SignatureKey { get; set; }
}