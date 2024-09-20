//Task task1 = new Task(() =>
//{
//    Console.WriteLine("Task Start");
//    Thread.Sleep(1000);
//    Console.WriteLine("Middle 1");
//    Thread.Sleep(1000);
//    Console.WriteLine("Middle 2");
//    Thread.Sleep(1000);
//    Console.WriteLine("Task End");
//});
//task1.Start();

//Task task2 = new Task(() =>
//{
//    Console.WriteLine("Salam");
//    Thread.Sleep(1000);
//    Console.WriteLine("...");
//    Thread.Sleep(1000);
//    Console.WriteLine("Sagol");
//});

//task2.Start();
//Task.WaitAny(task1, task2);
//Task.WaitAll(task1, task2);


//task.Start();

//task.ContinueWith(t =>
//{
//    Console.WriteLine("first");
//}).ContinueWith(t =>
//{
//    Console.WriteLine("second");
//}).ContinueWith(t =>
//{
//    Console.WriteLine("third");
//});



//Task<int> task = new Task<int>(() =>
//{
//    Thread.Sleep(3000);
//    Console.WriteLine("End Task");
//    return 100;
//});

//Console.WriteLine("Main Start");
//task.Start();
//Console.WriteLine(task.Result);
//Console.WriteLine("Main End");
//Console.WriteLine(task.Result);

//Console.ReadKey();



//var task = Task.Run(() => {});
//task.Wait();
/*
var task = Task.Run<string>(() =>
{
    //throw new Exception();
    Console.WriteLine("task<string>");
    return "Test";
});
//task.Wait();
Console.ReadKey();

//Console.WriteLine(task.Result);
*/


/*
using TasksApp;

User GetTheOldestUser()
{
    Thread.Sleep(5000);

    Console.WriteLine("User received from DB!");

    return new User
    {
        Id = 100,
        Name = "Elnur",
        Surname = "Mustafayev",
    };
}

Task<User> GetTheOldestUserAsync() => Task<User>.Run(() => GetTheOldestUser());

var getUserTask = GetTheOldestUserAsync();

for (int i = 0; i < 100; i++)
{
    Thread.Sleep(80);
    Console.Write(i);
}

var user = getUserTask.Result;
Console.WriteLine(user);
*/


// Создать метод GetMaxNumberAsync(params int[])

/*
int GetMaxNumber(params int[] nums)
{
    Thread.Sleep(3000);
    return nums.Max();
}

Task<int> GetMaxNumberAsync(params int[] nums)
{
    return Task.Run<int>(() =>
    {
        return GetMaxNumber(nums);
    });
}


//var result = GetMaxNumber(4,-2,8);
//Console.WriteLine(result);

var result = GetMaxNumberAsync(4,-2,8);
Console.WriteLine(result.Result);
*/