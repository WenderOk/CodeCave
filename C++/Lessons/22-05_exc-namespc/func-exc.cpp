#include <iostream>
 
void Some()
{
    int a{};
    int b{};

    try
    {
        std::cout << "Enter divider: ";
        std::cin >> b;
        std::cout << "Enter what to divide: ";
        std::cin >> a;
        if(b == 0)
            throw "Error: dividing by 0";
    }
    catch(const char* e)
    {
        std::cerr << e << '\n';
    }
}

int main()
{
    std::cout << "Before Some\n";
    Some();
    std::cout << "After Some\n";
 
    return 0;
}