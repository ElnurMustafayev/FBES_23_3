using System.Net;
using System.Net.Sockets;

const int serverPort = 7070;
IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
TcpListener tcpListener = new TcpListener(ipAddress, serverPort);

Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();

tcpListener.Start();
Console.WriteLine($"server started on port '{serverPort}'...");

async Task SendToAllAsync(string currentClientUsername, string clientMessage)
{
    foreach(var clientItem in clients)
    {
        if(clientItem.Key == currentClientUsername)
        {
            continue;
        }
        var anotherClientStream = clientItem.Value.GetStream();

        var anotherClientStreamWriter = new StreamWriter(anotherClientStream);

        await anotherClientStreamWriter.WriteLineAsync($"{currentClientUsername}: {clientMessage}");
        await anotherClientStreamWriter.FlushAsync();
    }
}

while(true)
{
    var tcpClient = await tcpListener.AcceptTcpClientAsync();
    Console.WriteLine("client accepted!");

    if(tcpClient.Client.RemoteEndPoint is IPEndPoint tcpClientIpEndpoint)
    {
        Console.WriteLine($"Client connected with port '{tcpClientIpEndpoint.Port}'");
    }

    _ = Task.Run(async () =>
    {
        var tcpClientStream = tcpClient.GetStream();

        var streamWriter = new StreamWriter(tcpClientStream);
        var streamReader = new StreamReader(tcpClientStream);

        await streamWriter.WriteLineAsync("Welcome to server! Input your username: ");
        await streamWriter.FlushAsync();

        string? clientUsername;

        // register user
        while (true)
        {
            try
            {
                clientUsername = await streamReader.ReadLineAsync();

                ArgumentException.ThrowIfNullOrWhiteSpace(clientUsername);

                clientUsername = clientUsername.Trim().ToLower();

                if(clients.ContainsKey(clientUsername))
                {
                    await streamWriter.WriteLineAsync($"Username '{clientUsername}' already exist! Try again: ");
                    await streamWriter.FlushAsync();
                    continue;
                }

                await SendToAllAsync(clientUsername, $"Client {clientUsername} joined...");
                clients.Add(clientUsername, tcpClient);
                await streamWriter.WriteLineAsync($"Hi, {clientUsername}!");
                await streamWriter.FlushAsync();
                break;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                await streamWriter.WriteLineAsync($"Error: '{ex.Message}'");
                await streamWriter.FlushAsync();
            }
        }

        while (true)
        {
            try
            {
                var clientMessage = await streamReader.ReadLineAsync();

                await SendToAllAsync(clientUsername, clientMessage);
            }
            catch(IOException)
            {
                await SendToAllAsync(clientUsername, $"Client {clientUsername} left...");
                clients.Remove(clientUsername);
            }
        }
    });
}