using System.Net.Sockets;
using System.Text;

const string eofKey = "end-of-file";
const int port = 8282;

var udpClient = new UdpClient(8282);

System.Console.WriteLine($"UDP client starting receivig on port: {port}");

while(true) {
    var buffer = new List<byte>();

    for (int packageCounter = 0; true; packageCounter++)
    {
        var result = await udpClient.ReceiveAsync();

        System.Console.WriteLine($"Package {packageCounter + 1} received from {result.RemoteEndPoint}");
        System.Console.WriteLine($"Package size: {result.Buffer.Length} bytes");

        var fileInBytes = result.Buffer;

        if(fileInBytes.Length == eofKey.Length && Encoding.UTF8.GetString(fileInBytes) == eofKey) {
            break;
        }

        buffer.AddRange(fileInBytes);
    }

    var filename = $"{DateTime.Now.ToString("ddMMyyyyhhmmss")}_{Guid.NewGuid().ToString("N")[..5]}.jpg";
    var filepath = $"Downloads/{filename}";
    
    await File.WriteAllBytesAsync(
        path: filepath,
        bytes: buffer.ToArray()
    );
    System.Console.WriteLine($"File created: {filepath}");
}



/*
while(true) {
    var result = await udpClient.ReceiveAsync();

    var message = Encoding.UTF8.GetString(result.Buffer);

    System.Console.WriteLine($"{result.RemoteEndPoint}: {message}"); 
}
*/