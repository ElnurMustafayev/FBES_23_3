using System.Text.Json.Serialization;

namespace AttributesApp;

public class User
{
    //[Invisible("asdasd")]
    public long Id { get; set; }
    public string Name { get; set; }
    [Invisible]
    public string Surname { get; set; }
}
