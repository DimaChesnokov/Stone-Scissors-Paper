using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientServer
{
    internal class RockPaperScissorsServer
    {
        static TcpListener server;
        static TcpClient player1;
        static TcpClient player2;

        static void Main()
        {
            try
            {
                int port = 8888;
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                Console.WriteLine("Ожидание игроков.");

                player1 = server.AcceptTcpClient();
                Console.WriteLine("Игрок 1 подключён.");
                SendNameRequest(player1);

                player2 = server.AcceptTcpClient();
                Console.WriteLine("Игрок 2 подключён.");
                SendNameRequest(player2);

                Thread thread1 = new Thread(() => HandlePlayer(player1, player2));
                thread1.Start();

                Thread thread2 = new Thread(() => HandlePlayer(player2, player1));
                thread2.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void HandlePlayer(TcpClient currentPlayer, TcpClient opponent)
        {
            NetworkStream stream = currentPlayer.GetStream();
            string playerName = GetPlayerName(currentPlayer);

            try
            {
                while (true)
                {
                    byte[] data = new byte[256];
                    int bytes = stream.Read(data, 0, data.Length);

                    if (bytes == 0)
                    {
                        Console.WriteLine($"{playerName} отключён.");
                        break;
                    }

                    string choice = Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine($"{playerName} выбор: {choice}");

                    SendChoice(opponent, playerName, choice);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }


        static void SendNameRequest(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("Введите ваше имя:");
            stream.Write(data, 0, data.Length);
        }

        static string GetPlayerName(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            return Encoding.UTF8.GetString(data, 0, bytes);
        }

        static void SendChoice(TcpClient recipient, string playerName, string choice)
        {
            NetworkStream stream = recipient.GetStream();
            byte[] data = Encoding.UTF8.GetBytes($"{playerName}: {choice}");
            stream.Write(data, 0, data.Length);
        }
    }
}
