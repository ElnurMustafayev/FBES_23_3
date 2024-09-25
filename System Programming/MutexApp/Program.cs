Mutex mutex = new Mutex(false, name: "MyMutex");

Console.WriteLine("Start App");

mutex.WaitOne();

Console.WriteLine("Open Mutex");
Console.ReadKey();

mutex.ReleaseMutex();

Console.WriteLine("End App");

Console.ReadKey();