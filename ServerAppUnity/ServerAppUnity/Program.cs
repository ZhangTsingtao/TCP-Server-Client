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
        
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            Console.WriteLine("Client connected!");

            byte[] buffer = new byte[1024];
            int bytesRead;

            bytesRead = stream.Read(buffer, 0, buffer.Length);
            if (bytesRead < 2) continue;

            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine(message);
        }
    }
}
