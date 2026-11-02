using System.Net;
using System.Net.Sockets;

IPAddress ip = IPAddress.Parse("127.0.1");
IPEndPoint ep = new IPEndPoint(ip, 1024);
Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

s.Bind(ep);
Console.WriteLine("Listening...");
s.Listen(10);

try
{
    while (true)
    {
        Socket ns = s.Accept();
        Console.WriteLine(ns.RemoteEndPoint?.ToString());
        ns.Send(System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString()));
        ns.Shutdown(SocketShutdown.Both);
        ns.Close();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
