using System.Net;
using System.Net.Sockets;
using System.Text; // IPAddress

// переменные для хранения адреса и портов, нужных для связи
int RemotePort;         // порт узла собеседника
int LocalPort;          // локальный порт
IPAddress RemoteIPAddr; // IP-адрес узла собеседника

try
{
    //Console.SetWindowSize(40, 20);
    Console.Title = "Чат";

    // получить от пользователя адрес и порты, нужные для связи
    Console.Write("Введите IP-адрес узла собеседника: ");
    RemoteIPAddr = IPAddress.Parse(Console.ReadLine() ?? "");
    Console.Write("Введите порт узла собеседника: ");
    RemotePort = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите локальный порт: ");
    LocalPort = Convert.ToInt32(Console.ReadLine());
    
    // создать и запустить отдельный поток для получения данных
    // (там тоже бесконечный цикл)
    Thread thread = new(new ThreadStart(ThreadFuncReceive));
    thread.IsBackground = true;
    thread.Start();
    
    // получать данные у пользователя и отсылать их собеседнику
    // (в бесконечном цикле)
    Console.ForegroundColor = ConsoleColor.Red;
    while (true)
    {
        SendData(Console.ReadLine() ?? "");
    }
}
catch (FormatException formEx)
{
    Console.WriteLine("Преобразование невозможно: " + formEx);
}
catch (Exception Ex)
{
    Console.WriteLine("Ошибка: " + Ex.Message);
}

// функция для получения данных в отдельном потоке
void ThreadFuncReceive()
{
    try
    {
        while (true)
        {
            // создать сокет нашей стороны, привязать к локальному порту
            UdpClient uClient = new(LocalPort);

            // получение сообщения-строки от собеседника
            IPEndPoint? ipEnd = null; // инфо об IP-адресе и порте собеседника
            byte[] response = uClient.Receive(ref ipEnd);
            string strResult = Encoding.Unicode.GetString(response);
            
            // вывести полученное сообщение в консоль
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(strResult);
            Console.ForegroundColor = ConsoleColor.Red;

            // закрыть сокет нашей стороны
            uClient.Close();
        }
    }
    catch (SocketException sockEx)
    {
        Console.WriteLine("Ошибка сокета: " + sockEx.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка: " + ex.Message);
    }
}

// функция для отправки данных
void SendData(string datagram)
{
    // создать сокет с нашей стороны
    UdpClient uClient = new();

    IPEndPoint ipEnd = new(RemoteIPAddr, RemotePort);
    try
    {
        // отправить сообщение-строку на указанные IP-адрес и порт
        byte[] bytes = Encoding.Unicode.GetBytes(datagram);
        uClient.Send(bytes, bytes.Length, ipEnd);
    }
    catch (SocketException sockEx)
    {
        Console.WriteLine("Ошибка сокета: " + sockEx.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка: " + ex.Message);
    }
    finally
    {
        // закрыть сокет с нашей стороны
        uClient.Close();
    }
}
