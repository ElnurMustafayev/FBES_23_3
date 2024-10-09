using SharedLib.Models;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

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

        string? username = null;

        while (true)
        {
            try
            {
                var clientRequestJson = await streamReader.ReadLineAsync();

                var clientRequest = JsonSerializer.Deserialize<Operation<object>>(clientRequestJson);

                switch(clientRequest.OperationName)
                {
                    case nameof(SetUsername):
                        var setUsernameOperation = JsonSerializer.Deserialize<Operation<SetUsername>>(clientRequestJson);

                        if(username == null)
                        {
                            username = setUsernameOperation.Data.NewUsername.Trim().ToLower();

                            if(clients.ContainsKey(username))
                            {
                                throw new ArgumentException($"Username '{username}' already taken!");
                            }

                            clients.Add(username, tcpClient);
                            await SendToAllAsync(username, $"User '{username}' joined!");
                        }
                        else
                        {
                            var newUsername = setUsernameOperation.Data.NewUsername.Trim().ToLower();

                            if(clients.ContainsKey(newUsername))
                            {
                                throw new ArgumentException($"Username '{newUsername}' already taken!");
                            }

                            clients.Remove(username);
                            var notificationText = $"User '{username}' changed username to '{newUsername}'!";
                            username = newUsername;
                            clients.Add(username, tcpClient);

                            await SendToAllAsync(username, notificationText);
                        }
                        break;
                    case nameof(SendMessage):
                        var sendMessageOperation = JsonSerializer.Deserialize<Operation<SendMessage>>(clientRequestJson);
                        if(username == null)
                        {
                            throw new Exception($"Register your user!");
                        }
                        var text = sendMessageOperation.Data.Message;
                        await SendToAllAsync(username, text);
                        break;
                    default:
                        break;
                }
            }
            catch(IOException)
            {
                break;
            }
            catch(Exception ex)
            {
                await streamWriter.WriteLineAsync($"{ex.GetType().Name}: {ex.Message}");
                await streamWriter.FlushAsync();
            }
        }
    });
}