namespace IdentityServiceApp.Options;

using System.Text;

public class JwtOptions
{
    public string Key { get; set; }
    public byte[] KeyInBytes => Encoding.ASCII.GetBytes(Key);
    public int LifeTimeInMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}