using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WindowsFormsRockScissorsPapier
{
    public partial class Form1 : Form
    {
        int port = 12345;// Порт для соединения
        StreamReader reader; // Поток для чтения
        StreamWriter writer; // Поток для записи
        int count = 0; // Счетчик партий
        bool sent_hand = false;// Флаг отправки руки(хода)
        bool read_hand = false;// Флаг получения руки(хода)
        string my_hand = ""; // Моя рука (мой ход)
        string op_hand = ""; // Рука оппонента (ход противника)
        public Form1()
        {
            InitializeComponent();
        }


        // Метод для управления доступностью кнопок
        private void setButtons(bool enable)
        {
            button1.Enabled = enable;
            button2.Enabled = enable;
            button3.Enabled = enable;
            button_clear.Enabled = enable;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (radio_server.Checked)
                StartServer(); // Запуск сервера

            if (radio_client.Checked)
                StartClient(); // Запуск клиента

            setButtons(true);
            timer.Enabled = true;
            text_debug.Text = text_debug.Text + "Соеднинение установлено" + Environment.NewLine;
            button_start.Enabled = false;
            //}
            //{
            //    MessageBox.Show("Убедитесь, что выбрали сервер и клиент");
            //}

        }
        //метод для запуска сервера
        private void StartServer()
        {
            //try
            //{

            //инициализация на каком ip адресе работать
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Parse(text_ip.Text), port)); // Инициализация слушателя
            listener.Start(); //запуск
            TcpClient server = listener.AcceptTcpClient(); //создание tcp клиента для сервера. ( Принятие клиента )
            server.ReceiveTimeout = 500;
            //потоки для чтения или записи
            reader = new StreamReader(server.GetStream()); // Получение потока для чтения
            writer = new StreamWriter(server.GetStream()); // Получение потока для записи
            writer.AutoFlush = true;
            //}
            //catch
            //{
            //    MessageBox.Show("Убедитесь, что выбрали сервер - клиент");
            //}
        }


        //Метод для запуска клиента
        private void StartClient()
        {


            // Создание нового клиента
            TcpClient client = new TcpClient();
            client.Connect(text_ip.Text, port);  // Подключение к серверу по указанному IP и порту
            client.ReceiveTimeout = 500;
            reader = new StreamReader(client.GetStream()); // Получение потока для чтения
            writer = new StreamWriter(client.GetStream()); // Получение потока для записи

            writer.AutoFlush = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            send("Камень");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            send("Ножницы");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            send("Бумага");
        }

        /// <summary>
        /// Метод для отправки данных о ходе
        /// </summary>
        /// <param name="text">Ход</param>
        private void send(string text)
        {
            //try
            //{
            if (sent_hand)
                return;
            writer.WriteLine(text);// Отправка текста через поток

            sent_hand = true; // Установка флага отправки
            my_hand = text; //Запись моего хода
            setButtons(false);
            //text_debug.Text = text_debug.Text + "Отправлено: " + text + Environment.NewLine;
            //}
            //catch
            //{
            //    MessageBox.Show("Убедитесь, что выбрали сервер - клиент");
            //}


        }


        /// <summary>
        /// Метод для чтения танных
        /// </summary>
        /// <returns></returns>
        private string read()
        {

            if (read_hand)
                return "";
            try
            {
                string text;
                text = reader.ReadLine(); // Чтение текста из потока
                // text_debug.Text = text_debug.Text +ы "Прочитано: " + text + Environment.NewLine;
                read_hand = true; // Установка флага получения
                op_hand = text;// Запись хода оппонента
                return text; // возращаем выбранный ход
            }
            catch
            {
                return "";
            }

        }
        //  обновление информации и проверка результата
        private void timer_Tick(object sender, EventArgs e)
        {

            //string  s = ()
            string hand = read();
            if (my_hand != "" & op_hand != "")
            {
                count = count + 1;
                text_debug.Text = text_debug.Text + "Партия " + count + Environment.NewLine;
                text_debug.Text = text_debug.Text + "Отправлено: " + my_hand + Environment.NewLine;
                text_debug.Text = text_debug.Text + "Прочитано: " + op_hand + Environment.NewLine;

            }


            if (sent_hand && read_hand)
            {

                ResultGame();
                text_debug.Text = text_debug.Text + " " + Environment.NewLine;
            }






        }

        private void ResultGame()
        {
            string res = CompareHand(my_hand, op_hand);
            text_debug.Text = text_debug.Text + "Мой ход: " + my_hand + Environment.NewLine;
            text_debug.Text = text_debug.Text + "Ход противника: " + op_hand + Environment.NewLine;
            label_result.Text = my_hand + " vs  " + op_hand + Environment.NewLine;
            label_result.Text = label_result.Text + res;
            sent_hand = false;
            read_hand = false;
            setButtons(true);
            my_hand = "";
            op_hand = "";
            System.Threading.Thread.Sleep(1000);
        }

        private string CompareHand(string hand1, string hand2)
        {
            if (hand1 == hand2)
                return "Ничья"; //ничья

            if (hand1 == "Камень")
                if (hand2 == "Ножницы")
                    return "Победа"; //первый
                else
                    return "Проигрыш"; // второй игрок

            if (hand1 == "Ножницы")
                if (hand2 == "Бумага")
                    return "Победа"; //первый
                else
                    return "Проигрыш"; // второй игрок

            if (hand1 == "Бумага")
                if (hand2 == "Камень")
                    return "Победа"; //первый
                else
                    return "Проигрыш"; // второй игрок
            return "Ничья";

        }



        private void button_clear_Click(object sender, EventArgs e)
        {

            text_debug.Text = "";
            count = 0;
            sent_hand = false;
            read_hand = false;
            my_hand = "";
            op_hand = "";
            label_result.Text = "";

        }
    }
}
