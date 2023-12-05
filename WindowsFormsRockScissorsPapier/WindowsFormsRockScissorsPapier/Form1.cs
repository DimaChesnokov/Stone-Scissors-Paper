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
        int port = 12345;
        StreamReader reader; //чтение
        StreamWriter writer; //запись
        int count = 0;
        bool sent_hand = false;
        bool read_hand = false;
        string my_hand = "";
        string op_hand = "";
        public Form1()
        {
            InitializeComponent();
        }

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
                StartServer();

            if (radio_client.Checked)
                StartClient();

            setButtons(true);
            timer.Enabled = true;
            text_debug.Text = text_debug.Text + "Соеднинение установлено" + Environment.NewLine;
            button_start.Enabled = false;
            //}
            //{
            //    MessageBox.Show("Убедитесь, что выбрали сервер и клиент");
            //}

        }

        private void StartServer()
        {
            //try
            //{
            //инициализация на каком ip адресе работать
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Parse(text_ip.Text), port));
            listener.Start(); //запуск
            TcpClient server = listener.AcceptTcpClient(); //создание tcp клиента для сервера. (принимаем) 
            server.ReceiveTimeout = 500;
            //потоки для чтения или записи
            reader = new StreamReader(server.GetStream()); //получаем поток для чтения
            writer = new StreamWriter(server.GetStream()); // для записи
            writer.AutoFlush = true;
            //}
            //catch
            //{
            //    MessageBox.Show("Убедитесь, что выбрали сервер - клиент");
            //}
        }

        private void StartClient()
        {



            TcpClient client = new TcpClient();
            client.Connect(text_ip.Text, port);
            client.ReceiveTimeout = 500;
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());

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

        private void send(string text)
        {
            //try
            //{
            if (sent_hand)
                return;
            writer.WriteLine(text);
            // text_debug.Text = text_debug.Text + "Отправлено: " + text + Environment.NewLine;
            sent_hand = true;
            my_hand = text;
            setButtons(false);
            //text_debug.Text = text_debug.Text + "Отправлено: " + text + Environment.NewLine;
            //}
            //catch
            //{
            //    MessageBox.Show("Убедитесь, что выбрали сервер - клиент");
            //}


        }

        private string read()
        {

            if (read_hand)
                return "";
            try
            {
                string text;
                text = reader.ReadLine();
                // text_debug.Text = text_debug.Text +ы "Прочитано: " + text + Environment.NewLine;
                read_hand = true;
                op_hand = text;



                return text;
            }
            catch
            {
                return "";
            }

        }

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
