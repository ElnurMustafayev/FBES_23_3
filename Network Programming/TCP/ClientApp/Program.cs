using System.Net;
using System.Net.Sockets;

const int serverPort = 7070;
IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
TcpClient tcpClient = new TcpClient();

await tcpClient.ConnectAsync(new IPEndPoint(ipAddress, serverPort));

var tcpClientStream = tcpClient.GetStream();

_ = Task.Run(async () =>
{
    var streamReader = new StreamReader(tcpClientStream);

    while(true)
    {
        var serverMessage = await streamReader.ReadLineAsync();

        Console.WriteLine(serverMessage);
    }
});



var writer = new StreamWriter(tcpClientStream);

while(true)
{
    var clientMessage = Console.ReadLine();
    await writer.WriteLineAsync(clientMessage);
    await writer.FlushAsync();
}