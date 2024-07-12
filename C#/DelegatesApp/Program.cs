using DelegatesApp;
using System;

/*
void PrintArray(string[] words, CheckWordDelegate wordChecker)
{
    foreach (var word in words)
    {
        if(wordChecker.Invoke(word))
        {
            Console.WriteLine(word);
        }
    }
}

string[] words =
{
    "Apple", "badword", "test", "pissoz"
};

bool BadWordsChecker(string word) => (word != "badword" && word != "pissoz");
bool LowerCaseChecker(string word) => word == word.ToLower();

PrintArray(words, LowerCaseChecker);
*/


/*
void IsGreater(int num1, int num2, CheckNumbersDelegate checker)
{
    if(checker.Invoke(num1, num2))
        Console.WriteLine("YES!");
    else
        Console.WriteLine("NO");
}

bool CheckTwoPositiveNumbers(int num1, int num2)
{
    return num1 > num2;
}

bool CheckTwoNonPositiveNumbers(int num1, int num2)
{
    if (num1 < 0 || num2 < 0)
        return false;

    return num1 > num2;
}

IsGreater(10, -5, CheckTwoNonPositiveNumbers);
*/










/*
void MyMethod(int num)
{
    Console.WriteLine($"Num: {num}");
}

void MySecondMethod(int num)
{
    Console.WriteLine($"{num + 1} - Test");
}

//var del1 = new MyDelegate(MyMethod);
MyDelegate del2 = MySecondMethod;
del2 += MySecondMethod;
del2 += MySecondMethod;
del2 += MyMethod;

del2.Invoke(123);
del2.Invoke(100);
*/



// PrintNumbers(nums: int[], checker: CheckNum)

// CheckIsOdd: bool
// CheckIsPositive: bool

/*
    Client code: 

    PrintNumbers(nums, CheckIsOdd);
    PrintNumbers(nums, CheckIsPositive);
*/





//T PrintObj<T>(T obj) where T : User
//{
//    Console.WriteLine(obj);

//    return obj;
//}



/*
T PrintObj<T>(T obj)
{
    Console.WriteLine(obj);

    return obj;
}

T PrintDecoratedObj<T>(T obj)
{
    Console.WriteLine($"***{obj}***");

    return obj;
}

PrintSomethingDelegate<int> delWithInts = PrintObj<int>;
delWithInts += PrintDecoratedObj<int>;

PrintSomethingDelegate<string> delWithStrings = PrintDecoratedObj<string>;

delWithInts.Invoke(777);
delWithStrings.Invoke("Test");
*/



// always returns void
/*
void Test() { }
void TestWith1Parameter(int num) { }
void TestWith3Parameters(int num, string str, double money) { }

Action action = Test;
Action<int> action1 = TestWith1Parameter;
Action<int, string, double> action2 = TestWith3Parameters;
action2.Invoke(123, "test", 12.5);
*/


/*
// always returns bool
bool CheckIsPositive(int num) => num > 0;
bool CheckIsInLowerCase(string str) => str == str.ToLower();

Predicate<int> predicate1 = CheckIsPositive;
Predicate<string> predicate2 = CheckIsInLowerCase;

Console.WriteLine(predicate1.Invoke(-2));
Console.WriteLine(predicate2.Invoke("test"));
*/


int GetNum() => 100;
string GetStr(double num) => num.ToString();

Func<int> func1 = GetNum;
Func<double, string> func2 = GetStr;

Console.WriteLine(func1().GetType().Name);
Console.WriteLine(func2(15.5).GetType().Name);