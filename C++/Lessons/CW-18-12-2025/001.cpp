#include <iostream>
#include <cstring>

int main()
{
    const int size{20};
    char* str{new char[size]{ "Hello fellow" }};
    const int size2{10};
    char* str2(new char[size2]);

    // std::strcpy(str2, str);
    std::strncpy(str2, str, size2);
    std::cout << str << '\n';
    std::cout << str2 << '\n';

    return 0;
}
