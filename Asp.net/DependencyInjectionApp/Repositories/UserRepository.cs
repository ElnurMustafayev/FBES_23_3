namespace DependencyInjectionApp.Repositories;

using DependencyInjectionApp.Models;
using DependencyInjectionApp.Repositories.Base;

public class UserRepository : IUserRepository
{
    private List<User> Users;

    public UserRepository() {
        Users = new List<User>();
        System.Console.WriteLine($"CTOR: {nameof(UserRepository)}");
    }
    
    public void CreateUser(User user) {
        Users.Add(user);
    }

    public User? GetUserById(int id) {
        return Users.FirstOrDefault(u => u.Id == id);
    }
}