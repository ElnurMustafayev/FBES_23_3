using ExceptionHandlingApp;

void MethodCanThrowException(bool toThrow = false)
{
    if(toThrow)
    {
        throw new Exception("My exception from Method!!!");
    }
}

try
{
    //int num = 0;
    //var result = 100 / num;
    //Console.WriteLine("TEST");

    //int[] nums = { 1, 2, 3 };
    //Console.WriteLine(nums[10]);

    throw new MyCustomException();

    MethodCanThrowException(true);

    var exception = new Exception("My exception!!!");

    throw exception;
}
catch(Exception ex)
{
    Console.WriteLine($"CATCH. Error: '{ex.Message}'");
}
finally {
    Console.WriteLine("FINALLY");
}