#pragma warning disable CS4014

int i = 0;
//Mutex mutex = new Mutex(false, "MyLockingMutex");
//Semaphore semaphore = new Semaphore(1,5);

object locker = 0;

var task1 = Task.Run(() =>
{
    Console.WriteLine("Thread 1 start");
    for (int j = 0; j < 10_000_000; j++)
    {
        lock(locker)
        {
            //Monitor.Enter(locker);
            //semaphore.WaitOne();
            //mutex.WaitOne();
            i++;
            //mutex.ReleaseMutex();
            //semaphore.Release();
            //Monitor.Exit(locker);
        }
    }
    Console.WriteLine("Thread 1 end");
});

var task2 = Task.Run(() =>
{
    Console.WriteLine("Thread 2 start");
    for (int j = 0; j < 10_000_000; j++)
    {
        lock (locker)
        {
            //Monitor.Enter(locker);
            //semaphore.WaitOne();
            //mutex.WaitOne();
            i++;
            //mutex.ReleaseMutex();
            //semaphore.Release();
            //Monitor.Exit(locker);
        }
    }
    Console.WriteLine("Thread 2 end");
});

Task.WaitAll(task1, task2);

Console.WriteLine(i);