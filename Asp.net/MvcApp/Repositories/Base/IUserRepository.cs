namespace MvcApp.Repositories.Base;

using MvcApp.Models;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(int id);
    void InsertUser(User user);
    bool DeleteUser(int id);
    bool UpdateUser(int id, User changedUser);
}