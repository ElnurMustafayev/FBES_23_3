using System.Data.SqlClient;
using Dapper;
using GettingStartedApp.Entities;

var connectionString = File.ReadAllText("connectionstring.txt");
var connection = new SqlConnection(connectionString);
connection.Open();

var teachers = connection.Query<Teacher>("select top 10 * from Teachers");

foreach (var teacher in teachers)
{
    Console.WriteLine($"{teacher.Id}: {teacher.Name}");
}

var lastTeacher = connection.QueryFirstOrDefault<Teacher>(@"select *
from Teachers
where Id = (select Max(Id) from Teachers)");

Console.WriteLine(lastTeacher);