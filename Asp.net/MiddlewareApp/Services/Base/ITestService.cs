namespace MiddlewareApp.Services.Base;

public interface ITestService
{
    void NeverCrashes();
    void DontPutNull(string? text);
    Task GoToDatabaseAsync();
}