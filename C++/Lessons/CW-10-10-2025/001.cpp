#include <iostream>
#include <math.h>

int main()
{
    int x1{};
    int y1{};
    std::cout << "Enter start position (x y): ";
    std::cin >> x1 >> y1;

    int x2{};
    int y2{};
    std::cout << "Enter end position (x y): ";
    std::cin >> x2 >> y2;

    if (x1==x2 || y1==y2)
    {
        std::cout << "Yes, horizantal or vertical move\n"; 
    }
    else if (std::abs(x1-x2) == std::abs(y1-y2))
    {
        std::cout << "Yes, diagonal move\n"; 
    }
    else
    {
        std::cout << "No\n"; 
    }

    return 0;
}