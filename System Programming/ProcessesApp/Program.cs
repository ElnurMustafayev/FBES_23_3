using System.Diagnostics;

if(false) {
    //Process.Start("calc.exe");
    //Process.Start("dotnet.exe");
    //Process.Start("mspaint.exe");
    //Process.Start("mspaint.exe");
    var chromeAbsolutePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
    var pageUrl = "https://lb.itstep.org/";
    //Process.Start(chromeAbsolutePath);
    //Process.Start(chromeAbsolutePath, pageUrl);
    //Process.Start(chromeAbsolutePath, new List<string> {pageUrl, pageUrl});

    var startInfo = new ProcessStartInfo {
        FileName = "ping",
        Arguments = "8.8.8.8"
    };

    //Process.Start(startInfo);
    var process = new Process {
        StartInfo = startInfo
    };
    process.Start();

    Console.ReadKey();
}

if(false) {
    var startInfo = new ProcessStartInfo {
        FileName = "mspaint",
    };

    var process = new Process {
        StartInfo = startInfo,
        EnableRaisingEvents = true,
    };

    process.Exited += (sender, arguments) => {
        System.Console.WriteLine("MY EXITED EVENT!");
    };

    process.Start();

    //Console.ReadKey();
    Thread.Sleep(60_000);
}

if(false) {
    var processes = Process.GetProcesses();

    foreach (var process in processes)
    {
        System.Console.WriteLine(process);
    }
}

if(false) {
    var foundProcesses = Process.GetProcessesByName("mspaint")
        ?.FirstOrDefault() ?? throw new ArgumentException("process not found", paramName: "mspaint");

    System.Console.WriteLine(foundProcesses.ProcessName);

    foundProcesses.Kill();
}

if(false) {
    System.Console.WriteLine("start");
    Process.GetCurrentProcess().Kill();
    System.Console.WriteLine("end");
}

var currentProcessId = Process.GetCurrentProcess().Id;
System.Console.WriteLine(currentProcessId);

Console.ReadKey();