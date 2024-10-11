using System.Net.Sockets;
using System.Text;

var udpClient = new UdpClient(7070);

while(true) {
    var message = Console.ReadLine();

    if(string.IsNullOrWhiteSpace(message))
        continue;

    var messageInBytes = Encoding.UTF8.GetBytes(message);

    await udpClient.SendAsync(messageInBytes, "localhost", 8282);
}