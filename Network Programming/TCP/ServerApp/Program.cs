using System.Net;
using System.Net.Sockets;
using System.Text;


const int serverPort = 7070;
IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
TcpListener tcpListener = new TcpListener(ipAddress, serverPort);

tcpListener.Start();
Console.WriteLine($"server started on port '{serverPort}'...");

while(true)
{
    var tcpClient = await tcpListener.AcceptTcpClientAsync();
    Console.WriteLine("client accepted!");

    if(tcpClient.Client.RemoteEndPoint is IPEndPoint tcpClientIpEndpoint)
    {
        Console.WriteLine($"Client connected with port '{tcpClientIpEndpoint.Port}'");
    }

    var tcpClientStream = tcpClient.GetStream();

    var streamWriter = new StreamWriter(tcpClientStream);

    Thread.Sleep(5000);

    await streamWriter.WriteLineAsync("Welcome to server!");
    await streamWriter.FlushAsync();

    //var welcomeMessage = "Welcome to server!";
    //var welcomeMessageInBytes = Encoding.UTF8.GetBytes(welcomeMessage);
    //await tcpClientStream.WriteAsync(welcomeMessageInBytes);
    //await tcpClientStream.FlushAsync();
}