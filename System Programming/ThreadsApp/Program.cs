/*
Console.WriteLine($"G 1 {Thread.CurrentThread.ManagedThreadId}");

// secondary 1
new Timer(
    callback: (state) =>
    {
        Console.WriteLine($"T 1 {Thread.CurrentThread.ManagedThreadId}");
    },
    state: null,
    dueTime: 1000,
    period: 1000);

// secondary 2
new Timer(
    callback: (state) =>
    {
        Console.WriteLine($"T 2 {Thread.CurrentThread.ManagedThreadId}");
    },
    state: null,
    dueTime: 0,
    period: 300);

// main
Console.WriteLine($"G 2 {Thread.CurrentThread.ManagedThreadId}");
while(true)
{
    Thread.Sleep(1000);
    Console.WriteLine($"M {Thread.CurrentThread.ManagedThreadId}");
}
*/

/*
Thread thread = new Thread((obj) =>
{
    Console.WriteLine("Start");
    Thread.Sleep(1000);
    Console.WriteLine("Middle");
    Thread.Sleep(1000);
    Console.WriteLine("End");
});

thread.Start();

Console.ReadKey();
*/

// [main]
// 1. [get from db]
// 2. [update]
// 3. [result output]

// [main] [secondary]
// 1. get from db
// 2. update
// 3. [add update result to logs]
// 4. result output

// [main]
// 1. get from db
// 2. update
// 3. add update result to logs 
// 4. result output

//[1234567890] -> 10 * 10 = 100
//[1234567890] -> 13


/*
int[] nums =
{
    1,2,3,4,5,6,7,8,9,10
};

// async
if(true)
{
    foreach (var num in nums)
    {
        var thread = new Thread(() =>
        {
            for (int i = 0; i < num; i++)
            {
                Thread.Sleep(1000);
                Console.Write($"{num}:{i} ");
            }
        });

        thread.Start();
    }

    Console.ReadKey();
}


// sync
if (false)
{
    foreach (var num in nums)
    {
        for (int i = 0; i < num; i++)
        {
            Thread.Sleep(1000);
            Console.Write($"{num}:{i} ");
        }
        Console.WriteLine();
    }
}
*/

//new Timer((state) =>
//{
//    Console.WriteLine("TIMER");
//}, null, 0, 500);

//Console.ReadKey();



//new Thread(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Thread.Sleep(500);
//        Console.WriteLine("THREAD");
//    }
//})
//{
//    IsBackground = false
//}.Start();

//Console.WriteLine("END");



/*
var thread1 = new Thread(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine("THREAD 1");
    }
});

Console.WriteLine("START");

thread1.Start();

Thread.Sleep(2000);
Console.WriteLine("DO WORK 1");
Thread.Sleep(500);
Console.WriteLine("DO WORK 2");
Thread.Sleep(700);
Console.WriteLine("DO WORK 3");

thread1.Join();

Console.WriteLine("DO WORK 4");
Console.WriteLine("END");
*/

/*
int GetRandomNumber()
{
    Thread.Sleep(3000);
    return Random.Shared.Next(10000);
}

int result = default;

var thread1 = new Thread(() =>
{
    result = GetRandomNumber();
});

thread1.Start();

Console.WriteLine("Welcome to my app");
Console.WriteLine("Press any ket to get random Number: ");

Console.ReadKey();
thread1.Join();

Console.WriteLine(result);
*/




using ThreadsApp;

Thread GetTheOldestUser(User user)
{
    Thread thread = new Thread(() =>
    {
        Thread.Sleep(2000);

        var foundUser = new User
        {
            Id = 1,
            Name = "Bob",
            Surname = "Marley",
        };

        user.Id = foundUser.Id;
        user.Name = foundUser.Name;
        user.Surname = foundUser.Surname;
    });

    thread.Start();

    return thread;
}

User user = new User();
Thread getTheOldestUserThread = GetTheOldestUser(user);

getTheOldestUserThread.Join();

Console.WriteLine(user);