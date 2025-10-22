#include <iostream>

int main()
{
    int x{};
    int y{};

    std::cout << "Enter x and y: ";
    std::cin >> x >> y;
    
    int res{x};

    for(int i{1}; i < y; i++)
    {
        res *= x;
    }

    std::cout << res << "\n";

    return 0;
}