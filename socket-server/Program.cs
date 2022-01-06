using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("### SERVER ###");

Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(IPEndPoint.Parse("127.0.0.1:1234"));
socket.Listen(0);

var service = new HelloService();

Console.WriteLine("waiting client...");

var clientSocket = socket.Accept();
var data = new byte[1024]; // OR clientSocket.ReceiveBufferSize
var count = clientSocket.Receive(data);

var message = Encoding.ASCII.GetString(data, 0, count);
var split = message.Split(';');
if (split[0] == "hello")
{
    var result = service.Hello(split[1]);
    Console.Write("Response:");
    Console.WriteLine(result);

    var response = Encoding.ASCII.GetBytes($"{result}");
    clientSocket.Send(response);
}
