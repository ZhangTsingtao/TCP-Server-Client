using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class SocketServer
{
    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 1462);
        server.Start();

        Console.WriteLine("Server started...");
        TcpClient client = server.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + message);
        }

        stream.Close();
        client.Close();
        server.Stop();
    }
}
