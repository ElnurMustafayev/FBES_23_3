using System;

int[] nums = [1, 2, 5, -100, 3, 0];

//var resultNums = nums.Append(10);

//foreach (var item in resultNums)
//{
//    Console.WriteLine(item);
//}


// Binary Tree
// this.MaxValue();
// ext.Max();

//Console.WriteLine(nums.Max());

//Console.WriteLine(nums.Count());
//Console.WriteLine(nums.Length);

bool IsPositive(int num)
{
    return num >= 0;
}

var result = nums.All(IsPositive);
//Console.WriteLine(result);

var positiveNumbersCount = nums.Count(IsPositive);
Console.WriteLine(nums.Count());
Console.WriteLine(positiveNumbersCount);
var lastPositiveNumber = nums.LastOrDefault(IsPositive, 777);
Console.WriteLine(lastPositiveNumber);
var positiveNumbers = nums.Where(IsPositive);

foreach (var item in positiveNumbers)
{
    Console.WriteLine(item);
}