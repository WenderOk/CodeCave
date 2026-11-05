#include <iostream>
#include <cstring>      // для функции strlen
#include <unistd.h>     // для функции close
#include <sys/socket.h> // для функций socket, bind, listen, accept, recv, send
#include <netinet/in.h> // для структуры sockaddr_in и функции htons
#include <arpa/inet.h>  // для функции inet_pton

int main()
{
    // 1. В Linux инициализация библиотеки сокетов не требуется (WSAStartup удален)

    // 2. Создать сокет (в Linux сокеты представлены обычными дескрипторами типа int)
    int skt = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (skt < 0) {
        std::cout << "Ошибка создания сокета\n";
        return 1;
    }

    // Опционально: разрешаем повторное использование адреса, чтобы избежать ошибки "Address already in use"
    int opt = 1;
    setsockopt(skt, SOL_SOCKET, SO_REUSEADDR, &opt, sizeof(opt));

    // 3. Привязать сокет к нужным IP-адресу и порту
    sockaddr_in addr{};
    addr.sin_family = AF_INET;
    inet_pton(AF_INET, "0.0.0.0", &addr.sin_addr); // слушает всё и везде
    addr.sin_port = htons(20000);
    
    if (bind(skt, reinterpret_cast<sockaddr*>(&addr), sizeof(addr)) < 0) {
        std::cout << "Ошибка bind\n";
        close(skt);
        return 1;
    }

    // 4. Установить сокет в режим прослушивания
    if (listen(skt, 1) < 0) {
        std::cout << "Ошибка listen\n";
        close(skt);
        return 1;
    }
    std::cout << "Сервер запущен и ждет подключений...\n";

    // 5. Принять подключение клиента
    int acceptSkt = accept(skt, nullptr, nullptr);
    if (acceptSkt < 0) {
        std::cout << "Ошибка приема подключения\n";
        close(skt);
        return 1;
    }

    // 6. Получить данные от клиента и вывести их в консоль
    const int MAXSTRLEN{ 255 };
    char buf[MAXSTRLEN]{};
    ssize_t bytes_recv = recv(acceptSkt, buf, MAXSTRLEN - 1, 0); // оставляем 1 байт для \0
    
    if (bytes_recv > 0) {
        buf[bytes_recv] = '\0';
        std::cout << buf << '\n';
    }

    // 7. Отправить данные клиенту
    const char* text{ "Hello from server! Привет от сервера!" };
    send(acceptSkt, text, strlen(text), 0);

    // 8. Закрыть сокеты (в Linux используется стандартная функция close)
    close(acceptSkt);
    close(skt);

    // 9. Освобождение ресурсов (WSACleanup удален)

    return 0;
}
