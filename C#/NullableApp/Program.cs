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





// bool result = HasVisa(double? money, bool? IsMarried);

// Виза выдаётся только в том случае,
// когда у человека +20к USD и когда он не холост