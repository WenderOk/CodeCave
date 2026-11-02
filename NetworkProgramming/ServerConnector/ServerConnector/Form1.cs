using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ServerConnector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //IPAddress ip = IPAddress.Parse("69.43.111.82");
            IPAddress ip = IPAddress.Parse(textBoxIP.Text);
            IPEndPoint ep = new IPEndPoint(ip, int.Parse(textBoxPort.Text));
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                s.Connect(ep);
                if (s.Connected)
                {
                    //String strSend = "GET\r\n\r\n";
                    string strSend = "GET / HTTP/1.1\r\nHost: web.simons.edu\r\n\r\n";
                    s.Send(System.Text.Encoding.ASCII.GetBytes(strSend));
                    byte[] buffer = new byte[1024];
                    int len;
                    do
                    {
                        len = s.Receive(buffer);
                        textBox1.Text += System.Text.Encoding.ASCII.GetString(buffer, 0, len);
                    } while (len > 0);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex) 
            {
                textBox1.Text = ex.Message;
                throw;
            }
            finally
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }
        }
    }
}
