#include <iostream>
int len(char* str);
int len2(char* str);

int main()
{
    // Runtime error //
    // char* str{"Hello!"};

    // std::cout << str << "\n";
    
    // str[3] = 'G';
    // std::cout << str << "\n";

    // Working well //
    char* str( new char[7]{ "Hello!" });
    // std::cout << str << "\n"; // Hello!

    str[3] = 'G';

    // std::cout << str << "\n"; // HelGo!
    // std::cout << str + 3 << "\n"; // lo!

    char* str2{"Helloh"};
    char* str3{""};
    std::cout << len(str2) << '\n';
    std::cout << len(str3) << '\n';
    std::cout << len2(str2) << '\n';
    return 0;
}

int len(char* str)
{
    int counter{};
    while (*str != '\0')
    {
        counter++;
        str++;
    }
    
    return counter;
}

int len2(char* str)
{
    int counter{};
    for(; *str != '\0'; str++)
        counter++;
    return counter;
}