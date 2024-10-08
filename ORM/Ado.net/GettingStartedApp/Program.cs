﻿using GettingStartedApp.Entities;
using GettingStartedApp.Repositories;
using GettingStartedApp.Services;

var repository = new TeachersAdonetRepository();
var service = new TeachersService(repository);

while (true)
{
    Console.Clear();
    System.Console.WriteLine(@"Press key to continue:
1 - add new teacher
2 - get teachers' count
3 - delete teacher by id
4 - print all teachers
5 - search by name
0 - exit" + Environment.NewLine);

    var pressedKey = Console.ReadKey().Key;
    Console.Clear();

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

        case ConsoleKey.D3:
            Console.Write("Input teacher id for delete: ");
            var idStr = Console.ReadLine();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(idStr);
            int id = int.Parse(idStr);
            bool wasDeleted = service.DeleteTeacherById(id);
            Console.WriteLine(wasDeleted ? "Teacher was successfully deleted!" : "Teacher not found!");
            break;

        case ConsoleKey.D4:
            service.PrintAllTeachers();
            break;

        case ConsoleKey.D5:
            Console.Write("Name: ");
            var nameToSearch = Console.ReadLine();
            service.PrintTeachersByName(nameToSearch);
            break;

        case ConsoleKey.D0:
            return;

        default:
            System.Console.WriteLine($"No implementation for key '{pressedKey}'!");
            return;
    }
    Console.ReadKey(true);
}