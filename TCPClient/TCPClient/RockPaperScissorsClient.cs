using System;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    internal class RockPaperScissorsClient
    {
        static void Main(string[] args)
        {
            try
            {
                int port = 8888;
                string serverIP = "127.0.0.1";
                TcpClient client = new TcpClient(serverIP, port);
                NetworkStream stream = client.GetStream();

                byte[] data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                Console.WriteLine(Encoding.UTF8.GetString(data, 0, bytes));

                string playerName = "";
                if (bytes > 0)
                {
                    Console.WriteLine("Введите ваше имя:");
                    playerName = Console.ReadLine();
                    data = Encoding.UTF8.GetBytes(playerName);
                    stream.Write(data, 0, data.Length);
                }

                Console.WriteLine("Добро пожаловать в камень - ножницы - бумага!");
                Console.WriteLine("Выбери чем будете ходить: камень, ножницы, бумага");
                string choice = Console.ReadLine().ToLower();

                data = Encoding.UTF8.GetBytes(choice);
                stream.Write(data, 0, data.Length);

                data = new byte[256];
                bytes = stream.Read(data, 0, data.Length);
                Console.WriteLine(Encoding.UTF8.GetString(data, 0, bytes));

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.WriteLine("Client closed.");
        }
    }
}
