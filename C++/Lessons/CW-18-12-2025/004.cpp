#include <iostream>
#include <cstring>
#include <cstdio>
#include <cctype>

void strup(char* str);

int main()
{
    char str[256];
    std::cout << "Enter name of the file: ";
    gets_s(str);
    char str2[256];
    std::strcpy(str2, str);
    strup(str2); 
    char* substr = std::strstr(str, ".TXT");
    int index{-1};
    if(substr) index = str2 - substr;

    if(!substr)
    {
        char* res{std::strchr(str, '.')};
        if(res) *res = '\0';
        std::cout << std::strcat(str, ".txt") << "\n";
    }
    else
        std::cout << "Extension .txt already exists.\n";

    return 0;
}

void strup(char* str)
{
    while(*str != '\0')
        *str = std::toupper(*str);
}