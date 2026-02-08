#include <iostream>

int main()
{
    short x{5};
    short y{3};
    std::cout << (x << 1) << "\n";

    x = 7;
    std::cout << (~x) << "\n";

    x = 5;
    y = 3;
    std::cout << (x & y) << "\n";
    std::cout << (x | y) << "\n";
    std::cout << (x ^ y) << "\n";
    short z{7};
    std::cout << (x ^ y ^ z) << "\n";

    std::cout << 15 << "\n";
    std::cout << 0x15 << "\n";
    std::cout << 015 << "\n";

    return 0;
}