int counter = 1;

System.Console.WriteLine("Version 2.0\n");

while(true) {
    Thread.Sleep(1000);
    System.Console.WriteLine($"{counter++} - Tack");

    Thread.Sleep(1000);
    System.Console.WriteLine($"{counter++} - Tick");
}