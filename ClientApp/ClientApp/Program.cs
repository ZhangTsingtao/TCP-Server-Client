using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static Socket socket;
        const int BUFFER_SIZE = 1024;
        static byte[] readBuff = new byte[BUFFER_SIZE];
        public static void Main(string[] args)
        {
            Console.Write("Client Hello World!!!\n");
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("129.21.196.206", 5050);
            int num = 0;
            while (true)
            {
                String str = "Client:Hello Heiren!!!";
                if (num == 0) num++;
                else str = Console.ReadLine();
                if (str.Equals("exit"))
                    break;
                byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
                socket.Send(bytes);
                int count = socket.Receive(readBuff);
                str = System.Text.Encoding.UTF8.GetString(readBuff, 0, count);
                Console.WriteLine(str);

            }

            socket.Close();

        }
    }
}
