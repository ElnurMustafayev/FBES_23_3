using GettingStartedApp.Entities;
using GettingStartedApp.Repositories;
using GettingStartedApp.Services;
using System.Diagnostics;

System.Console.WriteLine(@"Press key to continue:
1 - add new teacher
2 - get teachers' count" + Environment.NewLine);

var pressedKey = Console.ReadKey().Key;
Console.Clear();

var repository = new TeachersAdonetRepository();
var service = new TeachersService(repository);

switch (pressedKey)
{
    case ConsoleKey.D1:
        var createdTeacher = service.AddTeacher(out bool wasCreated);

        if (wasCreated)
            System.Console.WriteLine($"Teacher '{createdTeacher.Name}' was added successfully!");
        break;

    case ConsoleKey.D2:
        var count = service.GetTeachersCount();
        System.Console.WriteLine($"Teachers' count: {count}");
        break;

    default:
        System.Console.WriteLine($"No implementation for '{pressedKey}'!");
        break;
}



// Press key to continue:
// 1 - add new teacher
// 2 - get teachers' count
// 3 - delete teacher by id