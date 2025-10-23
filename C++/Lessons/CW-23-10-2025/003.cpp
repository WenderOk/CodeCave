#include <iostream>

int main()
{
    int x{};
    int y{};
    double res{};

    std::cout << "Enter start and end of range: ";
    std::cin >> x >> y;

    for(int i{x}; i <= y; i++)
    {
        res += i;
    }

    std::cout << res / y << "\n";

    return 0;
}