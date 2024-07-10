using DelegatesApp;

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