#include <iostream>

int main()
{
    int res{};

    for(int i{0}; i < 1000; i++)
    {
        res += i;
    }

    std::cout << res / 1000 << "\n";

    return 0;
}