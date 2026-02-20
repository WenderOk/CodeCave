#include <iostream>

int main()
{
    int x{};
    int* ptr{&x};

    std::cout << x << "\n" << ptr << "\n";

    return 0;
}

