namespace MvcApp.Repositories;

using MvcApp.Repositories.Base;
using MvcApp.Models;
using System.Collections.Generic;

public class UserRamRepository : IUserRepository
{
    private List<User> Users = new List<User>();

    public User? GetUserById(int id) {
        return this.Users.FirstOrDefault(u => u.Id == id);
    }

    public void InsertUser(User user) {
        this.Users.Add(user);
    }

    public bool DeleteUser(int id) {
        var userToDelete = this.GetUserById(id);
        if(userToDelete == null) {
            return false;
        }

        this.Users.Remove(userToDelete);
        return true;
    }

    public bool UpdateUser(int id, User changedUser) {
        var userToUpdate = this.GetUserById(id);
        if(userToUpdate == null) {
            return false;
        }
        
        userToUpdate.Id = changedUser.Id;
        userToUpdate.Name = changedUser.Name;
        userToUpdate.Surname = changedUser.Surname;
        return true;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return this.Users;
    }
}