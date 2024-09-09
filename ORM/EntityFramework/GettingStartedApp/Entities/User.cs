namespace GettingStartedApp.Entities;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public bool? IsMarried { get; set; }

    public override string ToString()
    {
        var output =  $"#{Id} | {Name} {Surname}";

        if(IsMarried != null) {
            output += " " + ((bool)IsMarried ? "married" : "not married");
        }

        return output;
    }
}