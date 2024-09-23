#pragma warning disable CS4014

int i = 0;

Task.Run(() =>
{
    Console.WriteLine("Thread 1 start");
    for (int j = 0; j < 10_000_000; j++)
    {
        i++;
    }
    Console.WriteLine("Thread 1 end");
});

Task.Run(() =>
{
    Console.WriteLine("Thread 2 start");
    for (int j = 0; j < 10_000_000; j++)
    {
        i++;
    }
    Console.WriteLine("Thread 2 end");
});

Console.ReadKey();

Console.WriteLine(i);