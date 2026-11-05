#pragma once

#include <iostream>
#include <string>     // для std::string
#include <cstring>    // для std::strcmp
#include <cstdlib>    // для std::exit
#include <winsock2.h> // для функций библиотеки WinSock2
#include <WS2tcpip.h> // для функции inet_pton

#pragma comment(lib, "ws2_32.lib")

const int MAXSTRLEN{ 255 };

class Socket
{
protected:
    WSADATA wsaData;  // информация об инициализации сокетов
    SOCKET skt;       // дескриптор слушающего сокета
    SOCKET acceptSkt; // дескриптор сокета клиента
    sockaddr_in addr; // адрес и порт
public:
    Socket();
    ~Socket();
    bool SendData(char* buffer);
    bool ReceiveData(char* buffer, int size);
    void CloseConnection();
    void SendDataMessage();
};

class ServerSocket: public Socket
{
public:
    void Bind(int port);
    void Listen();
    void StartHosting(int port);
};

class ClientSocket: public Socket
{
public:
    void ConnectToServer(const char* ip, int port);
};
