#include <iostream>

int main()
{
    double x{};
    int y{};

    std::cout << "Enter x and y: ";
    std::cin >> x >> y;
    
    double res{1};
    
    if (y > 0)
    {
        for(int i{}; i < y; i++)
            res *= x;
    }
    else if (y < 0)
    {
        if (x == 0)
        {
            std::cout << "You cant power by zero!\n";
            return 1;
        }
        for (int i{}; i > y; i--)
            res *= 1/x;
    }

    std::cout << res << "\n";

    return 0;
}