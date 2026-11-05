#include "socket.h" // классы и другие вещи для работы чата

// ===== реализация методов класса Socket =====

// конструктор: инициализировать библиотеку WinSock2, создать сокет в свойстве
// класса, отловить и обработать возможные ошибки
Socket::Socket()
{
    if (WSAStartup(MAKEWORD(2, 2), &wsaData) != NO_ERROR)
    {
        std::cout << "Ошибка при запуске функции WSAStartup!\n";
        WSACleanup();
        std::exit(10);
    }

    skt = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (skt == INVALID_SOCKET)
    {
        std::cout << "Ошибка при создании сокета!\n";
        WSACleanup();
        std::exit(11);
    }
}

// деструктор: очистить ресурсы, занятые ранее для работы с WinSock2
Socket::~Socket()
{
    WSACleanup();
}

// отправить сообщение, полученное через параметр, на сокет в свойстве класса
bool Socket::SendData(char* buffer)
{
    send(skt, buffer, std::strlen(buffer), 0);
    return true;
}

// получить сообщение с указанного в свойстве класса сокета и сохранить
// его в параметр
bool Socket::ReceiveData(char* buffer, int size)
{
    int recv_bytes{ recv(skt, buffer, size, 0) };
    buffer[recv_bytes] = '\0';
    return true;
}

// закрыть сокет в свойстве класса
void Socket::CloseConnection()
{
    closesocket(skt);
}

// получить у пользователя в консоли сообщение и вызвать метод SendData
// для передачи полученного сообщения на сокет в свойстве класса
void Socket::SendDataMessage()
{
    char message[MAXSTRLEN]{};
    std::cin.ignore(); // игнорировать символ новой строки, оставшийся от
                       // предыдущего ввода
    std::cout << "Введите сообщение: ";
    std::cin.get(message, MAXSTRLEN);
    SendData(message);
}

// ===== реализация методов класса ServerSocket =====

// привязать сокет из свойства класса к конечной точке (IP-адрес и порт),
// обработать возможную ошибку
void ServerSocket::Bind(int port)
{
    addr.sin_family = AF_INET;
    inet_pton(AF_INET, "0.0.0.0", &addr.sin_addr);
    addr.sin_port = htons(port);

    std::cout << "Привязываю слушающий сокет к порту: " << port << '\n';
    if (bind(skt, (SOCKADDR*)&addr, sizeof(addr)) == SOCKET_ERROR)
    {
        std::cout << "Привязка к порту не удалась!\n";
        WSACleanup();
        std::exit(14);
    }
}

// запустить прослушивание (ожидание подключений от клиентов) с помощью ранее
// созданного в свойстве класса слушающего сокета
void ServerSocket::Listen()
{
    std::cout << "Ожидаю подключения от клиента...\n";
    if (listen(skt, 1) == SOCKET_ERROR)
    {
        std::cout << "Ошибка при прослушивании (ожидании подключения от клиента)!\n";
        WSACleanup();
        std::exit(15);
    }

    acceptSkt = accept(skt, NULL, NULL);
    while (acceptSkt == SOCKET_ERROR)
    {
        acceptSkt = accept(skt, NULL, NULL);
    }
    skt = acceptSkt;
}

// запустить последовательно методы Bind и Listen класса для создания
// слушающего сокета (сокет со стороны сервера)
void ServerSocket::StartHosting(int port)
{
    Bind(port);
    Listen();
}

// ===== реализация методов класса ClientSocket =====


// подключиться к серверу со стороны клиента
void ClientSocket::ConnectToServer(const char* ipAddress, int port)
{
    addr.sin_family = AF_INET;
    inet_pton(AF_INET, ipAddress, &addr.sin_addr);
    addr.sin_port = htons(port);

    if (connect(skt, (SOCKADDR*)&addr, sizeof(addr)) == SOCKET_ERROR)
    {
        std::cout << "Не удалось подключиться к серверу!\n";
        WSACleanup();
        std::exit(13);
    }
}
