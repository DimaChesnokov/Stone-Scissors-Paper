using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientServer
{
    internal class RockPaperScissorsServer
    {
        static TcpListener server;
        static TcpClient player1;
        static TcpClient player2;


        //Для того чтобы позволить двум пользователям играть друг с
        //другом в камень, ножницы, бумагу через сервер, вам потребуется реализовать логику
        //обработки выборов обоих игроков на сервере. Давайте создадим простой сервер для этой
        //игры, который будет принимать соединения от двух клиентов и рассылать результаты их игры.


        //Запустите сервер и затем две копии клиентской части, каждую в своем отдельном окне или процессе.
        //Убедитесь, что клиенты подключаются к тому же IP-адресу и порту, на котором работает сервер.

        //Пример сервера для игры в камень, ножницы, бумагу:
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

                player2 = server.AcceptTcpClient();
                Console.WriteLine("Игрок 2 подключён.");

                Thread thread1 = new Thread(HandlePlayer);
                thread1.Start(player1);

                Thread thread2 = new Thread(HandlePlayer);
                thread2.Start(player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void HandlePlayer(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            string player = (client == player1) ? "Игрок 1" : "Игрок 2";

            try
            {
                while (true)
                {
                    byte[] data = new byte[256];
                    int bytes = stream.Read(data, 0, data.Length);

                    if (bytes == 0)
                    {
                        Console.WriteLine($"{player} отключён.");
                        break;
                    }

                    string choice = Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine($"{player} выбор: {choice}");

                    if (client == player1)
                    {
                        if (player2 != null)
                        {
                            SendChoice(player2, choice);
                        }
                    }
                    else if (client == player2)
                    {
                        if (player1 != null)
                        {
                            SendChoice(player1, choice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void SendChoice(TcpClient recipient, string choice)
        {
            NetworkStream stream = recipient.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(choice);
            stream.Write(data, 0, data.Length);
        }
    }
}

