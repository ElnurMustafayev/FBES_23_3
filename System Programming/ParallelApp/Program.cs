//Parallel.Invoke(
//    () => { Console.WriteLine("1"); },
//    () => { Console.WriteLine("22"); },
//    () => { Console.WriteLine("333"); },
//    () => { Console.WriteLine("4444"); },
//    () => { Console.WriteLine("55555"); }
//);



//Parallel.For(1, 5, (index) =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {index}");
//});


/*
using ParallelApp;


void ParallelPrintUsers(IEnumerable<User> users)
{
    Parallel.ForEach(users, user =>
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {user}");
    });
}


var users = new List<User>
{
    new User {
        Id = 1,
        Name = "Bob",
        Surname = "Marley",
    },
    new User {
        Id = 2,
        Name = "Ann",
        Surname = "Brown",
    }
};

ParallelPrintUsers(users);
*/




var nums = new int[]
{
    1,2,3,4,5,6,7,8,9
};

var parallelQuery = nums
    .AsParallel()
    .Where(num =>
    {
        Console.WriteLine(num);
        return true;
    });

Thread.Sleep(5000);

var result = parallelQuery.ToList();

Console.WriteLine(result);