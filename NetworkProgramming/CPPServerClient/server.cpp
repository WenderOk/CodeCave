#include "WinSock2.h"
#pragma comment(lib, "Ws2_32.lib")

int main()
{
    WSADATA wsaData{};

    // Step 1 Initializing Windows Socket API
    WSAStartup(MAKEWORD(2, 2), &wsaData);

    // Step 2 creating socket
    SOCKET sock;
    


}

