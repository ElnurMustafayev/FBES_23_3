//void SayHelloWorld()
//{
//    Console.WriteLine("Hello World!");
//}

//SayHelloWorld();
//SayHelloWorld();
//SayHelloWorld();

//int GetNumber()
//{
//    int number = 100;
//    Console.WriteLine($"Number: {number}");

//    return number;

//    Console.WriteLine($"Number: {number}");
//}

//Console.WriteLine(GetNumber());

//void Recursion()
//{
//    Recursion();
//    Console.WriteLine("Recursion");
//}

//Recursion();


/*
int num = 100;

void Method()
{
    Console.WriteLine(num--);
}

Method();
Console.WriteLine(num);
*/

/*
void Method1()
{
    Console.WriteLine("Method2");
    Method1();
    return;
}

void Method2()
{
    Console.WriteLine("Method1");
    Method1();
}

Method2();
*/

/*
void Method(int num)
{
    num = 777;
    Console.WriteLine(num);
}

int num = 100;
Method(num);
Console.WriteLine(num);
*/

/*
void ChangeArray(int[] nums)
{
    nums[0] = 777;
    Console.WriteLine(nums[0]);
}

int[] nums =
{
    1,2,3
};

Console.WriteLine(nums[0]);
ChangeArray(nums);
Console.WriteLine(nums[0]);
*/


/*
void Method(ref int num)
{
    num = 777;
}

int num = 100;
Method(ref num);
Console.WriteLine(num);
*/

/*
void ChangeName(char[] name)
{
    name = new char[] { 'A', 'n', 'n' };
}

char[] name = { 'B', 'o', 'b' };
ChangeName(name);
Console.WriteLine(name);
*/


/*
void Method(string[] names, decimal[] nums, ref int number, int num, string name = "Bob")
{
    // 2 + 3 + 100 + 3
    number = names.Length + nums.Length + num + name.Length;
}

int GetNumber()
{
    return 100;
}

decimal[] nums = { 1.2m, 3.4m, 5.6m };
int num = 100;
Method(new string[] { "Bob", "Ann" }, nums, ref num, GetNumber());

Console.WriteLine(num);
*/

Console.WriteLine(Random.Shared.Next());            // random
Console.WriteLine(Random.Shared.Next(100));         // 0 - 100
Console.WriteLine(Random.Shared.Next(0,10));        // 0 - 10