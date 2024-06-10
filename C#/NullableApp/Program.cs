//string name = null;

//Console.WriteLine(name);

/*
int? age = null;

var result = age + 4;

Console.WriteLine(result);
*/


/*
int? num = 100;

if(num != null)
{
    int result = num.Value;

    Console.WriteLine(result);
}

Console.WriteLine(num.Value);
*/

/*
int? num = 100;

var result = num == null ? 0 : num.Value;
*/


/*
int? num = null;

var result = num.HasValue ? num.Value : 0;

Console.WriteLine(result);
*/

/*
int? num = null;

var result = num.GetValueOrDefault(777);

Console.WriteLine(result);
*/



/*
int? GetSomething(bool flag)
{
    if(flag){
        return null;
    }
    else { 
        return -1; 
    }
}

int num = GetSomething(true).GetValueOrDefault(1);
Console.WriteLine(num);
*/



/*
void PrintMoney(decimal? money, char moneySymbol = '$')
{
    if(money.HasValue)
    {
        Console.WriteLine($"You have: {money}{moneySymbol}");
    }
    else
    {
        Console.WriteLine($"You have no money!");
    }
}

decimal money = 10.5m;

PrintMoney(money);
PrintMoney(111m);

decimal? wallet = null;
PrintMoney(wallet);
*/

/*
string[] names =
{
    "Ann", "Bob", "John"
};

string? GetRandomName()
{
    return Random.Shared.Next(0, 2) == 1
        ? null
        : names[Random.Shared.Next(0, names.Length)];
}
#pragma warning disable CS8600

string name = null;

string result1 = name!.ToUpper();
string? result2 = name?.ToUpper();

string result3 = result2 ?? "Unknown";

//Console.WriteLine(result2 ?? "Unknown");
Console.WriteLine(result2 ?? result1 ?? "Test" ?? result2);

#pragma warning restore CS8600

string test = "test";
Console.WriteLine(test?.Length);

int? num = 100;
var result = num?.ToString();
*/

//Console.WriteLine(result != null ? result : "Unknown");

/*
if (result != null)
{
    Console.WriteLine(result);
}
else
{
    Console.WriteLine("Unknown");
}
*/

/*
if (name != null)
{
    Console.WriteLine(name.ToUpper());
}
*/