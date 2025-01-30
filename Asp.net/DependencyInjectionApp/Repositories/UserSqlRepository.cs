namespace DependencyInjectionApp.Repositories;

using DependencyInjectionApp.Models;
using DependencyInjectionApp.Repositories.Base;

public class UserSqlRepository : IUserRepository
{
    private readonly string connectionString;

    public UserSqlRepository(string connectionString)
    {
        this.connectionString = connectionString;
        System.Console.WriteLine($"CTOR: {nameof(UserSqlRepository)} {this.GetHashCode()}");
    }

    public void CreateUser(User user)
    {
        System.Console.WriteLine($"Sql... {this.connectionString}");
    }

    public User? GetUserById(int id)
    {
        return null;
    }
}