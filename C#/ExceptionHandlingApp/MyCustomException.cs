namespace ExceptionHandlingApp;
class MyCustomException : Exception
{
    //public override string Message => "My custom error message!";

    public MyCustomException(string message) : base(message)
    {
        
    }
}