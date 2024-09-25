internal class Program
{
    private static async Task MyMethodAsync()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task.Run");
        });
    }

    private static async Task Loop()
    {
        for (int i = 0; i < 5; i++)
        {
            await MyMethodAsync();
        }
    }

    private static async Task Main(string[] args)
    {
        await Loop();

        while (true)
        {
            Thread.Sleep(300);
            Console.WriteLine("MAIN");
        }

        //Console.WriteLine("Start");
        //await MyMethodAsync();
        //MyMethodAsync().Wait();
        //MyMethodAsync().RunSynchronously();
        //MyMethodAsync();
        //Console.WriteLine("End");
    }
}