#include <iostream>
#include <cstring>
#include <cstdio>

int main()
{
    char str[256];
    char ch;
    std::cout << "Enter a string: ";
    gets_s(str);
    std::cout << "Enter a symbol to search: ";
    std::cin >> ch;

    char* res = std::strchr(str, ch);

    if(res)
        std::cout << res - str << "\n";
    else
        std::cout << "Symbol not found!\n";

    return 0;
}
