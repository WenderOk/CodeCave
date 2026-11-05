#include "socket.h" // классы и другие вещи для работы чата

int main()
{
    std::cout << "1. Запустить сервер (серверная часть)\n";
    std::cout << "2. Подключиться к серверу (клиентская часть)\n";
    std::cout << "3. Выход\n";
    std::cout << "Введите номер пункта: ";
    int nChoice{};
    std::cin >> nChoice;

    int port{ 24242 };                // выбор порта
    char receiveMessage[MAXSTRLEN]{}; // полученное сообщение
    char sendMessage[MAXSTRLEN];      // сообщение для отправки

    if (nChoice == 1)
    {
        ServerSocket server{};
        std::cout << "Запуск сервера...\n";
        server.StartHosting(port);
        while(true)
        {
            std::cout << "\tОжидание...\n";
            server.ReceiveData(receiveMessage, MAXSTRLEN);
            std::cout << "Получено: " << receiveMessage << '\n';
            server.SendDataMessage();
            // выход из бесконечного цикла
            if (std::strcmp(receiveMessage, "end") == 0 ||
                std::strcmp(sendMessage, "end") == 0)
            {
                break;
            }
        }
    }
    else if (nChoice == 2)
    {
        std::cout << "Введите IP-адрес для сервера: ";
        std::string ipAddress{};
        std::cin >> ipAddress;
        ClientSocket client{};
        client.ConnectToServer(ipAddress.c_str(), port);
        while(true)
        {
            client.SendDataMessage();
            std::cout << "\tОжидание...\n";
            client.ReceiveData(receiveMessage, MAXSTRLEN);
            std::cout << "Получено: " << receiveMessage << '\n';
            // выход из бесконечного цикла
            if (std::strcmp(receiveMessage, "end") == 0 ||
                std::strcmp(sendMessage, "end") == 0)
            {
                break;
            }
        }
        client.CloseConnection();
    }

    return 0;
}