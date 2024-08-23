namespace GettingStartedApp.Services;

using GettingStartedApp.Entities;
using GettingStartedApp.Repositories.Base;

public class TeachersService
{
    private readonly TeachersRepository repository;

    public TeachersService(TeachersRepository repository)
    {
        this.repository = repository;
    }

    public Teacher AddTeacher(out bool wasCreated)
    {
        var newTeacher = new Teacher();

        Console.WriteLine("New teacher's creating\n");

        Console.Write("Input name: ");
        newTeacher.Name = Console.ReadLine()?.Trim() ?? "Unknown";

        Console.Write("Input salary: ");
        newTeacher.Salary = double.Parse(Console.ReadLine() ?? "0");

        Console.Write("Input country: ");
        var countryIdStr = Console.ReadLine();
        if(countryIdStr == null || int.TryParse(countryIdStr, out int countryId) == false)
        {
            throw new ArgumentException("Country id is empty!", nameof(countryIdStr));
        }
        newTeacher.CountryId = countryId;

        wasCreated = this.repository.Insert(newTeacher);

        return newTeacher;
    }

    public int GetTeachersCount()
    {
        var count = this.repository.Count();

        return count;
    }
}