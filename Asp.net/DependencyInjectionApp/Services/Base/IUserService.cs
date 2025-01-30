namespace DependencyInjectionApp.Services.Base;

using DependencyInjectionApp.Models;

public interface IUserService
{
    void SignUp(User user);
}