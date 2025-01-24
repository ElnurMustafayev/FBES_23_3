namespace DependencyInjectionApp.Repositories;

using DependencyInjectionApp.Exceptions;
using DependencyInjectionApp.Models;
using DependencyInjectionApp.Repositories.Base;

public class UserWithValidationRepository : IUserRepository
{
    private List<User> Users;

    public UserWithValidationRepository() {
        Users = new List<User>();
        System.Console.WriteLine($"CTOR: {nameof(UserWithValidationRepository)}");
    }
    
    public void CreateUser(User user) {
        var validationException = new ValidationException();

        if(string.IsNullOrWhiteSpace(user.Name)) {
            validationException.validationResponseItems.Add(new ValidationResponse(nameof(user.Name), $"{nameof(user.Name)} can not be empty!"));
        }

        if(string.IsNullOrWhiteSpace(user.Surname)) {
            validationException.validationResponseItems.Add(new ValidationResponse(nameof(user.Surname), $"{nameof(user.Surname)} can not be empty!"));
        }

        if(user.Id <= 0) {
            validationException.validationResponseItems.Add(new ValidationResponse(nameof(user.Id), $"{nameof(user.Id)} can not be equal or less than 0!"));
        }

        if(validationException.validationResponseItems.Any() == false) {
            if(this.GetUserById(user.Id) != null) {
                validationException.validationResponseItems.Add(new ValidationResponse(nameof(user.Id), $"User with id '{user.Id}' already exist!"));
            }
        }

        if(validationException.validationResponseItems.Any()) {
            throw validationException;
        }

        Users.Add(user);
    }

    public User? GetUserById(int id) {
        return Users.FirstOrDefault(u => u.Id == id);
    }
}