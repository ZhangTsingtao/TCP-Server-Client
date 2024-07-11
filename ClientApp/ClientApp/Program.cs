using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace ClientSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
            connection:
                try
                {
                    
                    TcpClient client = new TcpClient("127.0.0.1", 1462);
                    Console.WriteLine("Connected, type in your message");
                    string clientMsg = Console.ReadLine();
                    string messageToSend = "'" + clientMsg + "'" + " from Tsingtao, " + DateTime.Now.ToString();
                    int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                    byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);

                    NetworkStream stream = client.GetStream();
                    stream.Write(sendData, 0, sendData.Length);
                    Console.WriteLine("Client: sending data to server...");

                    StreamReader sr = new StreamReader(stream);
                    string response = sr.ReadLine();
                    Console.WriteLine(response);

                    Console.WriteLine();
                    stream.Close();
                    client.Close();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("failed to connect... " + e.Message);
                    goto connection;
                }
            }
        }
    }
}