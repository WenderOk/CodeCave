#include <iostream>

int main()
{
    int x0{};
    int y0{};
    int r1{};
    int r2{};
    int x{};
    int y{};

    std::cout << "Enter coordinates of center (x y): ";
    std::cin >> x0 >> y0;

    std::cout << "Enter radius of ring (r1 r2): ";
    std::cin >> r1 >> r2;
    
    std::cout << "Enter coordinates of point(x y): ";
    std::cin >> x >> y;

    double L{ std::sqrt(std::pow(x0 - x, 2) + std::pow(y0 - y, 2)) };

    if (L < r2 && L > r1)
    {
        std::cout << "Point is on ring!\n";
    }
    else
    {
        std::cout << "Point isn't on ring!\n";
    }

    return 0;
}