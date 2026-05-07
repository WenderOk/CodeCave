#include <iostream>

int main()
{
    char* str{"Георгий"};
    for(int i{}; i <strlen(str); i++)
        std::cout << (int)str[i] << ' ';


    return 0;
}
