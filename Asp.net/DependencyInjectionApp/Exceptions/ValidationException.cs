namespace DependencyInjectionApp.Exceptions;

using DependencyInjectionApp.Models;

public class ValidationException : Exception
{
    public readonly List<ValidationResponse> validationResponseItems;

    public ValidationException()
    {
        validationResponseItems = new List<ValidationResponse>();
    }
}