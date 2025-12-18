#include <iostream>
#include <cstring>
#include <cstdio>
#include <cctype>

void strup(char* str);

int main()
{
    char phrase[256];
    char substr1[256];
    char substr2[256];
    std::cout << "Enter a phrase: ";
    gets_s(phrase);
    std::cout << "Enter a substring to be replaced: ";
    gets_s(substr1);
    std::cout << "Enter a substring to replace with: ";
    gets_s(substr2);
    char* res {std::strstr(phrase, substr1)};
    char begstr[256];
    if(res)
    {
        
    }


    return 0;
}

void strup(char* str)
{
    while(*str != '\0')
        *str = std::toupper(*str);
}