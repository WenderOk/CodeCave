using System.Net;
using System.Net.Sockets;

namespace _5UDPServer;

public partial class Form1 : Form
{
    delegate void AddTextDelegate(string text);
    Thread? thread;
    Socket? socket;
    CancellationTokenSource? cts; // токен для прерывания работы потока

    public Form1()
    {
        InitializeComponent();
    }

    void AddText(string text)
    {
        textBox1.Text += text;
    }

    void ReceiveFunction(object? obj)
    {
        if (cts == null) return; // проверка существования токена прерывания

        try
        {
            Socket? rs = obj as Socket;
            if (rs == null) return;

            byte[] buffer = new byte[1024];

            do
            {
                EndPoint ep = new IPEndPoint(0x7F000000, 100); // 127.0.0.0:100
                int len = rs.ReceiveFrom(buffer, ref ep);
                string strClientIP = ((IPEndPoint)ep).Address.ToString();
                string str = string.Format("\nПолучено от {0}\r\n{1}\r\n",
                    strClientIP,
                    System.Text.Encoding.Unicode.GetString(buffer, 0, len));
                textBox1.BeginInvoke(new AddTextDelegate(AddText), str);
                //} while (true);
            } while (!cts.Token.IsCancellationRequested); // пока не произойдет прерывание
        }
        catch (SocketException) when (cts.Token.IsCancellationRequested)
        {
            // ничего не делаем
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (socket != null && thread != null) return;

        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.IP);
        //socket.Bind(new IPEndPoint(IPAddress.Parse("10.2.21.129"), 100));
        socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.88.78"), 100)); // ipconfig
        cts = new CancellationTokenSource(); // создание токена прерывания потока
        thread = new Thread(ReceiveFunction);
        thread.Start(socket);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (socket == null) return;

        //thread.Abort();
        //thread?.Interrupt();
        cts?.Cancel(); // подать сигнал о прерывании потока через токен
        thread = null;
        
        socket.Shutdown(SocketShutdown.Receive);
        socket.Close();
        socket = null;

        textBox1.Text = "";
    }

    private void button3_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Socket socket = new(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.IP);

        socket.SendTo(System.Text.Encoding.Unicode.GetBytes(textBox2.Text),
            //new IPEndPoint(IPAddress.Parse("10.2.21.255"), 100));
            new IPEndPoint(IPAddress.Parse("192.168.88.255"), 100)); // всем в подсети

        socket.Shutdown(SocketShutdown.Send);
        socket.Close();
    }
}
