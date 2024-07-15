//int[] nums = [1, 2, 5, -100, 3, 0];

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


/*
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
*/


/*
void MyMethod(int num)
{
    Console.WriteLine($"method {num}");
}

Action<int> action = new Action<int>(MyMethod);
action += MyMethod;
action += delegate (int num)
{
    Console.WriteLine($"delegate {num}");
};
action += (num) => Console.WriteLine($"lambda {num}");
action += (num) =>
{
    Console.WriteLine($"lambda 1 line: {num}");
    Console.WriteLine($"lambda 2 line: {num}");
};

action.Invoke(123);
*/

/*
int total = 0;

Action<bool, int> action = (check, num) =>
{
    total += check ? num : -num;
};

Console.WriteLine(total);
action(true, 20);
action(false, 15);
Console.WriteLine(total);
*/



//Func<Action<string>, bool> func = delegate (Action<string> action) { return true; };
//Func<Action<string>, bool> func = (action) => true;
//Func<Action<string>, bool> func = (action) =>
//{
//    action.Invoke("func lambda");
//    return true;
//};

/*
Func<Action<string>, string, bool> func = (action, msg) =>
{
    action.Invoke(msg);
    return true;
};

func.Invoke((msg) => Console.WriteLine($"Message from action: {msg}"), "Hello");
*/



//Action<Predicate<int>, int> printIf = (checkNum, num) => Console.WriteLine(checkNum(num) ? num : null);

//Predicate<int> checkNum = (num) => num % 2 == 1;

//printIf(checkNum, 17);
//printIf(checkNum, 16);



/*
var result = nums.Where(num => num % 2 == 1);

//List<int> list2 = new List<int>();
List<int> list1 = result.ToList();

list1.ForEach(num => Console.WriteLine(num));
*/

//nums
//    .Where(num => num % 2 == 1)
//    .ToList()
//    .ForEach(num => Console.WriteLine(num));



IEnumerable<string> words = [ "something" ];
var containsBadword = words.Any(word => word.ToLower().Contains("badword"));