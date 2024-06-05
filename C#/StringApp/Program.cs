/*
string test = "Bob";
Console.WriteLine(test.Length);

string GetName()
{
    return "Bob";
}
Console.WriteLine(GetName().Length);

Console.WriteLine("Bob".Length);
*/

/*
string name = "Bob";
int compareResult = name.CompareTo("Bob");
Console.WriteLine(compareResult);
*/

/*
string name = "Bob";
bool contains = name.Contains("bo");
Console.WriteLine(contains);
*/

/*
string word = "QWERTY";
char[] wordChars = new char[10];
word.CopyTo(
    destinationIndex: 5, 
    destination: wordChars,
    sourceIndex: 3, 
    count: 2);

foreach (var item in wordChars)
{
    Console.Write($"*{item}* ");
}
*/

/*
string word = "QWERTY";
bool endsWith = word.EndsWith("ty", ignoreCase: true, null);

Console.WriteLine(endsWith);
*/

/*
string word = "QWERTY";
var result = word.IndexOf('R');

Console.WriteLine(result);
*/


/*
string fullname = "Bob Marley";

if(fullname.Contains("Bob"))
{
    Console.WriteLine("This is not Bob!");
}
*/

/*
string word = "QWERTY";
var index = word.IndexOfAny(new char[] { 'z', 'Y' });

Console.WriteLine(index);
*/

/*
//string word = "Bob";
//word += $" Mar{word}ley";

//Console.WriteLine(word);

string word = "Bob";
var result = word.Insert(1, "QWERTY");

Console.WriteLine(result);
*/

/*
string word = "bob";
Console.WriteLine($"First: {word.IndexOf('b')}");
Console.WriteLine($"Last: {word.LastIndexOf('b')}");
*/

/*
string word = "bob";
var wordWithLeftPadding = word.PadLeft(10);
var wordWithRightPadding = word.PadRight(10);

Console.WriteLine(wordWithLeftPadding);
Console.WriteLine(wordWithRightPadding);
*/

/*
string word = "qwerty";
var result = word.Remove(startIndex: 1, count: 2);

Console.WriteLine(result);
*/

/*
string word = "test testovich";
var result = word.Replace('t', 'T');

Console.WriteLine(result);
*/

/*
string word = "123,45,23,686,214";
string[] numberStrs = word.Split(',', ' ', ';', '/');

foreach (var numberStr in numberStrs)
{
    Console.WriteLine(numberStr);
}
*/

/*
string word = "Test";
var result = word.Substring(1, 2);

Console.WriteLine(result);
*/

/*
string word = "Te12st";
Console.WriteLine(word.ToUpper());
*/

/*
string word = "Привет, Bob";
var normalized = word.Normalize();

Console.WriteLine(normalized);
*/

/*
string fullname = " % Bob Marley    %%%";

Console.WriteLine($"*{fullname}*");
fullname = fullname.Trim('%', ' ');
Console.WriteLine($"*{fullname}*");
*/

// AA1234567 - AA;  length: 9;  digits: 7
// AZE123456 - AZE; length: 9;  digits: 6



while(true)
{
    Console.Write("Input serial number: ");
    string serialNumber = Console.ReadLine();
    var normalizedSerialNumber = serialNumber.ToUpper().Trim();
    bool serialNumberFormatValidation = true;
    string errorMessage = "";

    if(normalizedSerialNumber.Length != 9)
    {
        serialNumberFormatValidation = false;
        errorMessage = $"Lenth of serial number '{normalizedSerialNumber}' must be equal to 9!";
    }
    else if (normalizedSerialNumber.StartsWith("AA") || normalizedSerialNumber.StartsWith("AZE"))
    {
        int substringStartIndex = normalizedSerialNumber.StartsWith("AA") ? 2 : 3;

        var numberFromSerialStr = normalizedSerialNumber.Substring(substringStartIndex);

        foreach(char numberSymbol in numberFromSerialStr)
        {
            if(char.IsDigit(numberSymbol) == false)
            {
                serialNumberFormatValidation = false;
                errorMessage = $"symbol '{numberSymbol}' in serial number '{normalizedSerialNumber}' is not digit!";
                break;
            }
        }
    }
    else
    {
        serialNumberFormatValidation = false;
        errorMessage = $"Serial number '{normalizedSerialNumber}' has incorrect format!";
    }

    if(serialNumberFormatValidation)
    {
        Console.WriteLine("OK");
    }
    else
    {
        Console.WriteLine(errorMessage);
    }
}