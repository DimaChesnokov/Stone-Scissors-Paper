using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    //Для игры "камень, ножницы, бумага" клиентская часть должна позволить игрокам вводить свой выбор
    //и отправлять его серверу для соперничества с другим игроком.
    //Вот пример кода для клиентской части игры:

    //Этот код представляет простую клиентскую часть игры.
    //Он подключается к серверу, позволяет игроку ввести свой выбор (камень, ножницы или бумага) и отправляет его серверу.
    //Затем клиент ожидает ответа от сервера с выбором оппонента и выводит его на экран.

    internal class RockPaperScissorsClient
    {
        static void Main(string[] args)
        {
            try
            {
                // Установка порта и IP-адреса сервера
                int port = 8888;
                string serverIP = "127.0.0.1";

                // Создание экземпляра TcpClient для соединения с сервером
                TcpClient client = new TcpClient(serverIP, port);

                // Получение потока для передачи и получения данных от сервера
                NetworkStream stream = client.GetStream();

                // Приветствие и запрос выбора игрового хода от пользователя
                Console.WriteLine("Добро пожаловать в камень - ножницы - бумага!");
                Console.WriteLine("Выбери чем будете ходить: камень, ножницы, бумага");
                string choice = Console.ReadLine().ToLower();

                // Преобразование выбора пользователя в массив байтов и отправка на сервер
                byte[] data = Encoding.UTF8.GetBytes(choice);
                stream.Write(data, 0, data.Length);

                // Получение ответа (выбора оппонента) от сервера
                data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                string opponentChoice = Encoding.UTF8.GetString(data, 0, bytes);

                // Вывод выбора оппонента на экран
                Console.WriteLine($"Opponent's choice: {opponentChoice}");

                // Закрытие потока и клиента после завершения игры
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                // Обработка и вывод исключения, если оно возникло
                Console.WriteLine($"Exception: {ex.Message}");
            }

            // Уведомление о закрытии клиента
            Console.WriteLine("Client closed.");
        }
    }
}
