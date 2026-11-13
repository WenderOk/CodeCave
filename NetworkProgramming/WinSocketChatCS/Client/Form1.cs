using System.Net;         // IPEndPoint
using System.Net.Sockets; // TcpClient, SocketException
using System.Text;        // Encoding

namespace Client;

public partial class Form1 : Form
{
    TcpClient? client = null;

    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            // установить соединение с указанной конечной точкой
            IPEndPoint ep = new(IPAddress.Parse(textBox1.Text),
                                Convert.ToInt32(textBox2.Text));
            client = new TcpClient();
            client.Connect(ep);

            // отправить сообщение
            NetworkStream nstream = client.GetStream();
            byte[] barray = Encoding.Unicode.GetBytes(textBox3.Text);
            nstream.Write(barray, 0, barray.Length);
            client.Close();
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

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (client != null)
        {
            client.Close();
        }
    }
}
