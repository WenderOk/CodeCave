#include <iostream>
#include <cstdio>
#include <cstring>

int main()
{
    const int MAXLEN{ 256 };
    char str[MAXLEN]{};

    std::cout << "Enter string: ";
    gets_s(str);
    std::cout << "You enter: " << str << '\n';
    std::cout << "Lenght: " << std::strlen(str) << '\n';

    return 0;
}
