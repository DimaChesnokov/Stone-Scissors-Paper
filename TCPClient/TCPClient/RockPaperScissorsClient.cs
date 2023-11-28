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
                int port = 8888;
                string serverIP = "127.0.0.1";

                TcpClient client = new TcpClient(serverIP, port);

                NetworkStream stream = client.GetStream();

                Console.WriteLine("Добро пожаловать в камень - ножницы - бумага!");
                Console.WriteLine("Выбери чем будете ходить: камень, ножницы, бумага");
                string choice = Console.ReadLine().ToLower();

                byte[] data = Encoding.UTF8.GetBytes(choice);
                stream.Write(data, 0, data.Length);

                data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                string opponentChoice = Encoding.UTF8.GetString(data, 0, bytes);

                Console.WriteLine($"Opponent's choice: {opponentChoice}");

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
