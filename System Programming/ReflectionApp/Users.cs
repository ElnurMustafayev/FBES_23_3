namespace ReflectionApp;

using System.Text.Json.Serialization;

public class User
{
    private string password = "VerySecretPassword";

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Firstname { get; set; }
    
    [JsonPropertyName("surname")]
    public string Lastname { get; set; }

    [JsonIgnore]
    public string Fullname => $"{Firstname} {Lastname}";

    public User(long id, string firstname, string lastname)
    {
        this.Id = id;
        this.Firstname = firstname;
        this.Lastname = lastname;
    }

    public User()
    {
        this.Id = default;
        this.Firstname = string.Empty;
        this.Lastname = string.Empty;
    }

    public override string ToString() => $"{Id} {Firstname} {Lastname} {Fullname}";
}