#include <iostream>

int main()
{
    // char str[]{'H', 'e', 'l', 'l', 'o', '!', '\0'};
    char str[]{"Hello!"};

    // for(int i{}; str[i] != '\0'; i++)
    // {
    //     std::cout << str[i];
    // }
    std::cout << str << "\n";
    str[5] = '#';
    std::cout << str << "\n";

    return 0;
}