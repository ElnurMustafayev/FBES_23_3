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