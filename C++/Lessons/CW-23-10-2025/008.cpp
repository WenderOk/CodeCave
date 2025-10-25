#include <iostream>

int main ()
{
    int res{};

    for (int i{}; i <= 12; i++)
    {
        res += i;
    }

    std::cout << res << "\n";

    return 0;
}