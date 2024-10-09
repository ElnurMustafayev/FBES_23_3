namespace SharedLib.Models;

public class Operation<T>
{
    public string OperationName { get; set; }

    public T Data { get; set; }
}