namespace DependencyInjectionApp.Repositories;

using DependencyInjectionApp.Models;

public class UserRepository
{
    private static List<User> Users;

    static UserRepository() {
        Users = new List<User>();
    }
    
    public void CreateUser(User user) {
        Users.Add(user);
    }

    public User? GetUserById(int id) {
        return Users.FirstOrDefault(u => u.Id == id);
    }
}