using System.Net.Sockets;
using System.Text;

var udpClient = new UdpClient(8282);

while(true) {
    var result = await udpClient.ReceiveAsync();

    var message = Encoding.UTF8.GetString(result.Buffer);

    System.Console.WriteLine($"{result.RemoteEndPoint}: {message}"); 
}