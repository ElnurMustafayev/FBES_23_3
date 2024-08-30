namespace GettingStartedApp.Repositories;

using GettingStartedApp.Entities;
using GettingStartedApp.Repositories.Base;
using System.Data.SqlClient;

public class TeachersAdonetRepository : TeachersRepository
{
    public override bool Insert(Teacher teacher)
    {
        string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

        var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            cmdText: @$"insert into Teachers ([Name], [Salary], [CountryId]) 
        values	('{teacher.Name}', {teacher.Salary}, {teacher.CountryId})",
            connection: connection
        );

        int affectedRowsCount = command.ExecuteNonQuery();

        return affectedRowsCount > 0;
    }

    public override int Count()
    {
        string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

        var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            cmdText: "select count(*) from Teachers",
            connection: connection
        );

        object result = command.ExecuteScalar();

        return (int)result;
    }

    public override bool Delete(int id)
    {
        string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

        var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            cmdText: $"delete from Teachers where Id = {id}",
            connection: connection
        );

        int affectedRowsCount = command.ExecuteNonQuery();

        return affectedRowsCount > 0;
    }

    public override IEnumerable<Teacher> Select()
    {
        string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

        var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand("select * from Teachers", connection);

        var reader = command.ExecuteReader();

        var teachers = new List<Teacher>();

        while (reader.Read())
        {
            var currentTeacher = new Teacher
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Salary = reader.GetDecimal(2),
                CountryId = reader.GetInt32(3),
            };

            teachers.Add(currentTeacher);
        }

        return teachers;
    }
}