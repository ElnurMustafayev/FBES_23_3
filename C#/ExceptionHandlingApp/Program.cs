using ExceptionHandlingApp;

int GetIndexOf<T>(T[] nums, T searchValue)
{
    Console.WriteLine($"{nameof(GetIndexOf)} method start!");
    Console.WriteLine($"Overload for type: {typeof(T)}");

    for (int i = 0; i < nums.Length; i++)
    {
        if(object.Equals(nums[i], searchValue))
        {
            return i;
        }
    }

    throw new ItemNotFoundInCollectionException<T>(collection: nums, searchValue: searchValue);
}

int searchValue = 56;
int[] nums = { 1, 2, 3 };

try
{
    // var index = GetIndexOf<int>(nums, searchValue);
    int num = 0;
    Console.WriteLine(100 / num);
    var index = GetIndexOf(nums, searchValue);
    Console.WriteLine($"Index: {index}");
}
catch(ItemNotFoundInCollectionException<int> ex)
{
    Console.WriteLine($"Your {nameof(Int32)} value: " + ex.SearchValue);
    Console.WriteLine($"Error: {ex.Message}");
}
catch(ItemNotFoundInCollectionException<double> ex)
{
    Console.WriteLine($"Your {nameof(Double)} value: " + ex.SearchValue);
    Console.WriteLine($"Error: {ex.Message}");
}
catch(Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}



/*
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

    throw new MyCustomException("Test");

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
*/