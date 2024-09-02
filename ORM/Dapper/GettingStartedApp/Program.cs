using System.Data.SqlClient;
using Dapper;
using GettingStartedApp.DynamicQueryParams;
using GettingStartedApp.Entities;



if(false)
{
    // update name by id
    Console.Write("Input teacher's id: ");
    var idToSearch = Console.ReadLine();

    Console.Write("New name: ");
    var newName = Console.ReadLine();

    var connectionString = File.ReadAllText("connectionstring.txt");
    var connection = new SqlConnection(connectionString);

    connection.Open();

    var affectedRowsCount = connection.Execute(
        sql: @"update Teachers
set Name = @Name
where Id = @Id",
        param: new
        {
            Id = long.Parse(idToSearch),
            Name = newName,
        });

    Console.WriteLine(affectedRowsCount);
}





if (false)
{
    Console.Write("Input teacher's id to search: ");
    var idToSearch = Console.ReadLine();

    var connectionString = File.ReadAllText("connectionstring.txt");
    var connection = new SqlConnection(connectionString);

    connection.Open();

    var teacher = connection.QueryFirst<Teacher>(
        sql: $@"select *
            from Teachers
            where Id = @Id",
        param: new SelectByIdParams
        {
            Id = idToSearch,
        }
        );

    connection.Close();

    Console.WriteLine(teacher);
}





if (false)
{
    Console.Write("Input teacher's name to search: ");
    var nameToSearch = Console.ReadLine();

    var connectionString = File.ReadAllText("connectionstring.txt");
    var connection = new SqlConnection(connectionString);

    connection.Open();

    var teacher = connection.QueryFirst<Teacher>(
        sql: $@"select *
            from Teachers
            where Name = @Name",
        param: new SelectByNameParams {
            Name = nameToSearch,
        }
        );

    connection.Close();

    Console.WriteLine(teacher);
}



if(false)
{
    var connectionString = File.ReadAllText("connectionstring.txt");
    var connection = new SqlConnection(connectionString);

    var teachers = connection.Query<Teacher>("select top 10 * from Teachers");

    foreach (var teacher in teachers)
    {
        Console.WriteLine($"{teacher.Id}: {teacher.Name}");
    }

    var lastTeacher = connection.QueryFirstOrDefault<Teacher>(@"select *
    from Teachers
    where Id = (select Max(Id) from Teachers)");

    Console.WriteLine(lastTeacher);
}
