namespace DependencyInjectionApp.Services;

using DependencyInjectionApp.Exceptions;
using DependencyInjectionApp.Models;
using DependencyInjectionApp.Repositories.Base;
using DependencyInjectionApp.Services.Base;

public class UserService : IUserService
{
    private readonly IUserRepository repository;
    
    public UserService(IUserRepository repository)
    {
        this.repository = repository;
        System.Console.WriteLine($"CTOR: {nameof(UserService)} {this.GetHashCode()}");
    }

    public void SignUp(User user)
    {
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
            if(this.repository.GetUserById(user.Id) != null) {
                validationException.validationResponseItems.Add(new ValidationResponse(nameof(user.Id), $"User with id '{user.Id}' already exist!"));
            }
        }

        if(validationException.validationResponseItems.Any()) {
            throw validationException;
        }

        this.repository.CreateUser(user);
    }
}