namespace DependencyInjectionApp.Models;

public class ValidationResponse
{
    public string Property { get; set; }
    public string Message { get; set; }

    public ValidationResponse(string property, string message)
    {
        this.Property = property;
        this.Message = message;
    }
}