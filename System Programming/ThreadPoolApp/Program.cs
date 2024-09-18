//Thread thread = new Thread(() =>
//{
//    while (true)
//    {
//        Console.WriteLine("asdasdasd");
//    }
//});
//thread.Start();

//thread.Abort();

//WaitCallback callback = (obj) =>
//{
//    Console.WriteLine(obj);
//};

//ThreadPool.QueueUserWorkItem(callback, 123);

//Console.ReadKey();



//ThreadPool.GetMaxThreads(out int t1, out int t2);
//Console.WriteLine(t1);
//Console.WriteLine(t2);
//ThreadPool.SetMaxThreads(2, 2);

/*
ThreadPool.QueueUserWorkItem((obj) =>
{
    Console.WriteLine($"THREAD 1 start: {Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(1000);
    Console.WriteLine($"THREAD 1 end: {Thread.CurrentThread.ManagedThreadId}");
});

ThreadPool.QueueUserWorkItem((obj) =>
{
    Console.WriteLine($"THREAD 2: {Thread.CurrentThread.ManagedThreadId}");
});

Console.ReadKey();

ThreadPool.QueueUserWorkItem((obj) =>
{
    Console.WriteLine($"THREAD 3: {Thread.CurrentThread.ManagedThreadId}");
});

Console.ReadKey();
*/

using ThreadPoolApp;

User user = new User();

ThreadPool.QueueUserWorkItem<User>((state) =>
{
    state.Id = 123;
    state.Name = "CHANGED";
    state.Surname = "CHANGED";
}, user, true);

Console.ReadKey();

Console.WriteLine(user);