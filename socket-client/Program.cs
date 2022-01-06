Console.WriteLine("#### CLIENT #####");
Console.Write("name: ");
var name = Console.ReadLine() ?? "";
var service = new HelloService();
var response = service.Hello(name);

Console.Write("Response:");
Console.WriteLine(response);

Console.WriteLine("exit!");
