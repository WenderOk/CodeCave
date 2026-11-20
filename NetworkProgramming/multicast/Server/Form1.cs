namespace Server;

public partial class Form1 : Form
{
    static string Message = "Hello, net";
    static int interval = 1000;
    Thread Sender = new(new ThreadStart(MulticastSend));
    public Form1()
    {
        InitializeCustomComponents();
        Sender.IsBackground = true;
        Sender.Start();
    }

    static void MulticastSend()
    {
        while (true)
        {
            Thread.Sleep(interval);

            Socket skt = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocalType.Udp);
            skt.SetSocketOption(SocketoptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);

            IPAddess dest = IPAdress.Parse("244.5.5.5");
            skt.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(dest));

            IPEndPoint ipEP = new(dest, 4567);

            skt.Connect(ipEP);
            skt.Send(Encoding.UTF8.Getbytes(Message));
            skt.Close();
        }
    }

    private void InitializeCustomComponents()
    {
        // Настройка самой формы
        this.Text = "Server";
        this.Size = new Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;

        // Инициализация и настройка TextBox
        mainTextBox = new TextBox
        {
            Multiline = true,                        // Разрешаем многострочный ввод
            Dock = DockStyle.Fill,                   // Растягиваем на всё окно
            ScrollBars = ScrollBars.Vertical,        // Добавляем вертикальную полосу прокрутки
            AcceptsTab = true,                       // Разрешаем ввод табуляции (Tab)
            AcceptsReturn = true,                    // Разрешаем перенос строки по Enter
            Font = new Font("Consolas", 12F),        // Удобный шрифт для текста
            BorderStyle = BorderStyle.None           // Убираем лишнюю рамку по краям окна
        };

        // Добавляем TextBox на форму
        this.Controls.Add(mainTextBox);
    }
}
