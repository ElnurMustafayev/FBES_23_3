namespace DependencyInjectionApp.Repositories.Base;

using DependencyInjectionApp.Models;

public interface IUserRepository
{
    User? GetUserById(int id);
    void CreateUser(User user);
}