#include <iostream>
 

int main()
{
    std::cout << "Start\n";

    try
    {
        std::cout << "Before throwing error\n";
        throw 100; // ошибка типа int
        std::cout << "After throwing error\n";
    }
    catch(int e)
    {
        std::cerr << "Exception" << '\n';
    }

    std::cout << "End\n";
    
    return 0;
}