namespace GettingStartedApp.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int CountryId { get; set; }

    public override string ToString() => $"{Id}: {Name} {Salary}$ {CountryId}";
}