using System.Net;
using System.Net.Sockets;
using System.Text;

const int serverPort = 7070;
IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
TcpClient tcpClient = new TcpClient();

await tcpClient.ConnectAsync(new IPEndPoint(ipAddress, serverPort));

var tcpClientStream = tcpClient.GetStream();
var streamReader = new StreamReader(tcpClientStream);

var messageFromServer = await streamReader.ReadLineAsync();

//byte[] buffer = new byte[1024];
//var size = tcpClientStream.Read(buffer, 0, buffer.Length);
//var messageFromServer = Encoding.UTF8.GetString(buffer, 0, size);

Console.WriteLine($"Server: '{messageFromServer}'");