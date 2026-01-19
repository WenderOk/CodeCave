#include <iostream>

int main()
{
    int x{ 25 };
    decltype(x) y{ 12 };
    std::cout << x << " " << y << "\n";

    const int& g{ x };
    auto a{ g };
    a = 78;
    std::cout << x << "\n";

    return 0;
}