/*
bool MethodWithIn(in int num)
{
    //num = 100;
    Console.WriteLine(num);
    return true;
}

bool TryParse(string numStr, out int result)
{
    try
    {
        result = Convert.ToInt32(numStr);
        return true;
    }
    catch
    {
        result = 0;
        return false;
    }
}
*/




int Sum(int[] nums, out bool isResultPositiv)
{
    int sum = 0;
    foreach (var num in nums)
    {
        sum += num;
    }

    isResultPositiv = sum >= 0;

    return sum;
}

int[] nums = { 1, 2, 3, -10 };
int sum = Sum(nums, out bool isResultPositiv);

Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Is result positive: {(isResultPositiv ? "yes" : "no")}");