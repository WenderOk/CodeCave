using System.Net;
using System.Net.Sockets;

namespace _6AsyncUDPServerClient;

public partial class Form1 : Form
{
    Socket? socket;
    class StateObject
    {
        public Socket? WorkSocket;
        public const int BufferSize = 1024;
        public byte[] Buffer = new byte[BufferSize];
    }
    StateObject state = new();
    EndPoint ClientEP = new IPEndPoint(IPAddress.Any, 100);
    IAsyncResult? RcptRes, SendRes;
    delegate void AddTextDelegate(string text);

    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (socket != null) return;

        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.IP);
        //socket.Bind(new IPEndPoint(IPAddress.Parse("10.2.21.129"), 100));
        socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.88.78"), 100)); // ipconfig

        state.WorkSocket = socket;
        RcptRes = socket.BeginReceiveFrom(state.Buffer, 0,
            StateObject.BufferSize, SocketFlags.None, ref ClientEP,
            new AsyncCallback(Receive_Completed), state);

    }

    void Receive_Completed(IAsyncResult ia)
    {
        try
        {
            StateObject? so = ia.AsyncState as StateObject;
            
            if (so == null) return;
            Socket? client = so.WorkSocket;

            if (client == null || RcptRes == null) return;
            int readed = client.EndReceiveFrom(RcptRes, ref ClientEP);

            string strClientEP = ((IPEndPoint)ClientEP).Address.ToString();

            string str = string.Format("\n�������� �� {0}\r\n{1}\r\n",
                strClientEP,
                System.Text.Encoding.Unicode.GetString(so.Buffer, 0, readed));

            textBox1.BeginInvoke(new AddTextDelegate(AddText), str);
            RcptRes = socket?.BeginReceiveFrom(state.Buffer, 0,
                StateObject.BufferSize, SocketFlags.None, ref ClientEP,
                new AsyncCallback(Receive_Completed), state);
        }
        catch (SocketException)
        {
            // ������ �� ������
        }
    }

    void AddText(string text)
    {
        textBox1.Text += text;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        socket?.Shutdown(SocketShutdown.Receive);
        socket?.Close();
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

        byte[] buffer = System.Text.Encoding.Unicode.GetBytes(textBox2.Text);
        SendRes = socket.BeginSendTo(buffer, 0, buffer.Count(), SocketFlags.None,
            //new IPEndPoint(IPAddress.Parse("10.2.21.255"), 100),
            new IPEndPoint(IPAddress.Parse("192.168.88.255"), 100), // ���� � �������
            new AsyncCallback(Send_Completed), socket);
    }

    void Send_Completed(IAsyncResult ia)
    {
        Socket? socket = ia.AsyncState as Socket;
        if (socket == null || SendRes == null) return;

        socket.EndSend(SendRes);
        socket.Shutdown(SocketShutdown.Send);
        socket.Close();
    }
}
