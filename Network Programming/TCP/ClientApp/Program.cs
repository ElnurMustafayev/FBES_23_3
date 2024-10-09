using SharedLib.Models;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

const int serverPort = 7070;
IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
TcpClient tcpClient = new TcpClient();

await tcpClient.ConnectAsync(new IPEndPoint(ipAddress, serverPort));

var tcpClientStream = tcpClient.GetStream();

var streamReader = new StreamReader(tcpClientStream);
var streamWriter = new StreamWriter(tcpClientStream);

_ = Task.Run(async () =>
{
    while(true)
    {
        var serverRequestTxt = await streamReader.ReadLineAsync();
        Console.WriteLine(serverRequestTxt);
    }
});


// set username
Console.Write("Enter your username: ");
var username = Console.ReadLine();

var setUsernameOperation = new Operation<SetUsername>
{
    OperationName = nameof(SetUsername),
    Data = new SetUsername
    {
        OldUsername = null,
        NewUsername = username,
    }
};

var setUsernameOperationJson = JsonSerializer.Serialize(setUsernameOperation);
await streamWriter.WriteLineAsync(setUsernameOperationJson);
await streamWriter.FlushAsync();


// send message
while(true)
{
    var message = Console.ReadLine();

    var sendMessageOperation = new Operation<SendMessage>
    {
        OperationName = nameof(SendMessage),
        Data = new SendMessage
        {
            Author = username,
            Message = message,
        }
    };

    var sendMessageOperationJson = JsonSerializer.Serialize(sendMessageOperation);

    await streamWriter.WriteLineAsync(sendMessageOperationJson);
    await streamWriter.FlushAsync();
}