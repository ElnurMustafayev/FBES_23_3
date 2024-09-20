using System.Diagnostics;
using TimerApp;

/*
TimerCounter counter = new TimerCounter(0);

TimerCallback timerCallback = (state) => {
    if(state is TimerCounter timerCounter) {
        timerCounter.Iterator++;
        System.Console.WriteLine($"TICK: {timerCounter.Iterator}");
    }
    else {
        System.Console.WriteLine("TICK");
    }
};

Timer timer = new Timer(
    callback: timerCallback,
    state: counter,
    dueTime: 2000,
    period: 1000
);

Console.ReadKey();
System.Console.WriteLine($"1. Timer counter: {counter.Iterator}");
Console.ReadKey();
System.Console.WriteLine($"2. Timer counter: {counter.Iterator}");
Console.ReadKey();
System.Console.WriteLine($"3. Timer counter: {counter.Iterator}");
Console.ReadKey();
*/

var timer = new Timer(
    callback: (state) => {
        var groupedProcesses = Process.GetProcesses()
            .GroupBy(p => p.ProcessName)
            .Take(30);

        List<Tuple<string, int>> processesInfo = new List<Tuple<string, int>>(groupedProcesses.Count());
        foreach (var item in groupedProcesses)
        {
            try {
                PerformanceCounter PC = new PerformanceCounter();
                PC.CategoryName = "Process";
                PC.CounterName = "Working Set - Private";
                PC.InstanceName = item.Key;
                int memsize = Convert.ToInt32(PC.NextValue()) / (int)(1024);
                PC.Close();
                PC.Dispose();
                processesInfo.Add(new Tuple<string, int>($"{item.Key} ({item.Count()}) - {memsize}", memsize));
            }
            catch {}
        } 

        Console.Clear();
        processesInfo
            .OrderByDescending(t => t.Item2)
            .ToList()
            .ForEach(output => System.Console.WriteLine(output));
    },
    state: null,
    dueTime: 0,
    period: 1000
);

// timer.Change(dueTime: 1000, period: 2000);

Console.ReadKey();