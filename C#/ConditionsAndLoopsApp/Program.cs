/*
if(false)
{
    Console.WriteLine("IF");
}
else if(true)
    Console.WriteLine("ELSE IF");
else
{
    Console.WriteLine("ELSE");
}
 */





//int num = 100;
//Console.WriteLine(num);

//string result = Console.ReadLine();

/*
var result1 = Console.Read();
var result2 = Console.Read();

Console.WriteLine(result1);
Console.WriteLine(result2);
*/

/*
var key = Console.ReadKey();
Console.WriteLine(key.Key);
 */


//Console.Write("Input your Name: ");
//var name = Console.ReadLine();

//var resultMessage = "Your name is " + name;
//Console.WriteLine(resultMessage);

//Console.WriteLine("Your name is {0}", name);

//Console.WriteLine("{1} => {0}", "One", "Two");


// What is your height? (in sm): 
// Your height is '...' sm

//Console.WriteLine("What is your height? (in sm): ");
//Console.WriteLine("Your height is \"{0}\" sm", Console.ReadLine());
//Console.WriteLine(@"Your height is ""{0}"" sm", Console.ReadLine());

//string text = @"Hello!
//How are you?


//test";
//Console.WriteLine(text);

//Console.Write("What is your height? (in sm): ");
//Console.WriteLine(@"Hello!
//Your height is ""{0}"" sm", Console.ReadLine());

/*
Console.Write("What is your height? (in sm): ");
var heightInput = Console.ReadLine();
Console.WriteLine($"Your height is '{heightInput}' sm");
Console.WriteLine($"Your height is '{Console.ReadLine()}' sm");
Console.WriteLine($"Your height is '{177}' sm");
*/


//Console.Write("What is your height? (in sm): ");
//var heightInputStr = Console.ReadLine();

//var heigth = Convert.ToInt32(heightInputStr);

//if(heigth > 0)
//{
//    Console.WriteLine($"Your height is '{heigth}' sm");
//}
//else
//{
//    Console.WriteLine($"Heigth can not be equal or less than 0! Your input is: {heigth}");
//}



// Input the 1-st operand: ...
// Input the 2-nd operand: ...
// "{...} / {...} = {result}"

/*
Console.Write("Input the 1-st operand: ");
var firstNum = Convert.ToDouble(Console.ReadLine());

Console.Write("Input the 2-nd operand: ");
var secondNum = Convert.ToDouble(Console.ReadLine());

var divResult = firstNum / secondNum;
Console.WriteLine($"{firstNum} / {secondNum} = {divResult}");
*/


/*
Console.WriteLine("Start");
Console.ReadKey();
Console.Clear();
Console.ReadKey();
Console.WriteLine("End");
*/

/*
Console.WriteLine("1. One");
Console.WriteLine("2. Two");
Console.WriteLine("3. Three");

Console.WriteLine("Select operation: ");
var operationInput = Console.ReadLine();
Console.Clear();

switch(operationInput)
{
    case "1":
        Console.WriteLine("ONE");
        break;
    case "2":
        Console.WriteLine("TWO");
        break;
    case "3":
        Console.WriteLine("THREE");
        break;
    default:
        Console.WriteLine($"Your selection '{operationInput}' have no implementation!");
        break;
}
*/


/*

const int menuMinIndex = 0;
const int menuMaxIndex = 2;
int currentIndex = menuMinIndex;

while(true)
{
    Console.Clear();

    if(currentIndex == 0)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("1. One");
        Console.ResetColor();
        // background
    }
    else
    {
        Console.WriteLine("1. One");
    }

    if(currentIndex == 1)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("2. Two");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("2. Two");
    }

    if(currentIndex == 2)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("3. Three");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("3. Three");
    }

    ConsoleKeyInfo redKeyResult = Console.ReadKey();
    ConsoleKey key = redKeyResult.Key;

    if(key == ConsoleKey.UpArrow)
    {
        if(currentIndex > menuMinIndex)
        {
            currentIndex--;
        }
    }
    else if(key == ConsoleKey.DownArrow)
    {
        if(currentIndex < menuMaxIndex)
        {
            currentIndex++;
        }
    }
    else if(key == ConsoleKey.Enter)
    {
        // TODO...
    }
}

*/



//while (true)
//{
//    continue;
//    break;
//}


//for(Console.WriteLine("A"); true; Console.WriteLine("C"))
//{
//    Console.WriteLine("D");
//}


//for(a; b; c) { d }
// a b d c b d c



//int counter = 0;

//foreach (var item in "Hello World")
//{
//    if(counter > 5)
//        break;
//    Console.WriteLine($"#{counter++}: {item}");
//}



// необходимо создать консольное приложение,
// в котором от лица пользователя будет угадываться слово

// допустим:
// в приложении загадано слово "Paint"
// пользователь пишет слова до тех пор, пока не отгадает слово

// доп. условия:
// у пользователя есть максимум 3 попытки


string secretWord = "Paint";
int maxTries = 3;
bool won = false;

for (int tryCounter = 0; won == false && tryCounter < maxTries; tryCounter++)
{
    Console.Clear();
    Console.WriteLine($"{tryCounter + 1} of {maxTries} try...");
    Console.Write("Input word: ");
    var word = Console.ReadLine();

    if(word == secretWord)
    {
        Console.WriteLine("YOU WIN!");
        won = true;
    }
}

if(!won)
{
    Console.WriteLine("YOU LOSE!");
}