#include <iostream>

void strcpy(char* src, char* dest);

int main()
{
    char* str{new char[10]{ "Hello" }};
    char* str2(new char[10]);

    str2 = str;
    std::cout << str2 << '\n';

    return 0;
}

void strcpy(char* src, char* dest)
{
    for(; *src != '\0'; src++, dest++) \
        *dest = *src;
    *dest = '\0';
}