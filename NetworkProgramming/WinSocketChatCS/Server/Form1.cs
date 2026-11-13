using System.Net;         // IPAddress
using System.Net.Sockets; // TcpListener, TcpClient, SocketException
using System.Text;        // Encoding

namespace Server;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    TcpListener? listener = null;

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            listener = new TcpListener(IPAddress.Parse(textBox1.Text),
                                       Convert.ToInt32(textBox2.Text));
            listener.Start(); // начать прослушивание клиентов

            // создание потока для чтения сообщения от клиента
            Thread thread = new Thread(new ThreadStart(ThreadFunction));
            thread.IsBackground = true;
            thread.Start();
        }
        catch (SocketException SockEx)
        {
            MessageBox.Show("Ошибка сокета: " + SockEx.Message);
        }
        catch (Exception Ex)
        {
            MessageBox.Show("Ошибка: " + Ex.Message);
        }
    }

    void ThreadFunction()
    {
        while (true)
        {
            if (listener == null) return;

            TcpClient client = listener.AcceptTcpClient();
            StreamReader reader = new StreamReader(client.GetStream(),
                Encoding.Unicode);
            string? str = reader.ReadLine();

            // добавить полученное сообщение в список и закрыть соединение
            if (str != null)
            {
                messageList.Items.Add(str);
            }
            client.Close();

            // при получении сообщения "EXIT" завершить работу приложения
            if (str != null)
            {
                if (str.ToUpper() == "EXIT")
                {
                    listener.Stop();
                    this.Close();
                }
            }
        }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (listener != null)
        {
            listener.Stop();
        }
    }
}
