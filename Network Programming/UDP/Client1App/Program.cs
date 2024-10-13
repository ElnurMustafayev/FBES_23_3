using System.Net.Sockets;
using System.Text;

const int udpPackageSize = 10_000;
const string eofKey = "end-of-file";
var eofInBytes = Encoding.UTF8.GetBytes(eofKey);

var udpClient = new UdpClient(7070);

while(true) {
    try {
        Console.Clear();
        System.Console.Write("Input file name: ");
        var filename = Console.ReadLine();
        ArgumentNullException.ThrowIfNullOrWhiteSpace(filename, nameof(filename));

        var filepath = $"Assets/{filename}";

        if(File.Exists(filepath) == false) {
            throw new ArgumentException($"File '{filepath}' not found!");
        }

        var fileInBytes = await File.ReadAllBytesAsync(filepath);

        // package logic
        for (int packageCounter = 0; true; packageCounter++)
        {
            // if(packageCounter > 3 && packageCounter < 8) {
            //     continue;
            // }

            var fileInBytesPackage = fileInBytes
                .Skip(udpPackageSize * packageCounter)
                .Take(udpPackageSize).ToArray();

            // end of file
            if(fileInBytesPackage.Any() == false) {
                break;
            }

            //Thread.Sleep(1000);
            await udpClient.SendAsync(fileInBytesPackage, "localhost", 8282);
            System.Console.WriteLine($"Package {packageCounter + 1} sent! lenght: {fileInBytesPackage.Length}");
        }
        
        //Thread.Sleep(1000);
        await udpClient.SendAsync(eofInBytes, "localhost", 8282);
        System.Console.WriteLine($"File {filename} sent!");
        Console.ReadKey();
    }
    catch(Exception ex) {
        System.Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}




/*
while(true) {
    var message = Console.ReadLine();

    if(string.IsNullOrWhiteSpace(message))
        continue;

    var messageInBytes = Encoding.UTF8.GetBytes(message);

    await udpClient.SendAsync(messageInBytes, "localhost", 8282);
}
*/