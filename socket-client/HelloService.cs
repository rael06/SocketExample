using System.Net;
using System.Net.Sockets;
using System.Text;

public class HelloService
{
    private Socket _socket;

    public HelloService()
    {
        Console.WriteLine("Creating socket...");
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _socket.Connect(IPEndPoint.Parse("127.0.0.1:1234"));

        Console.WriteLine("client connected");
    }

    public string Hello(string name)
    {
        Console.WriteLine("sending hello packet...");
        var data = Encoding.ASCII.GetBytes($"hello;{name}");
        _socket.Send(data);

        var buffer = new byte[1024];
        var bytesReceived = _socket.Receive(buffer);
        var response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

        return response;
    }
}
