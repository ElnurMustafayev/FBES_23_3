namespace MyApp.Infrastructure.Services;

using MyApp.Core.Models;
using MyApp.Core.Services;

public class TestService : ITestService
{
    public void Test(Person person)
    {
        System.Console.WriteLine("Test method");
    }
}