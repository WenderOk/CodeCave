#include <iostream>
#include <cstring>

int main()
{
    const int size{256};
    char str[size]{"Hello "};
    char str2[size]{"World"};
    char str3[size]{"!"};
    
    std::strcat(std::strcat(str, str2), str3);

    std::cout << str << '\n';

    return 0;
}
