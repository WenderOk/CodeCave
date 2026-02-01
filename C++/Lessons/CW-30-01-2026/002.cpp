#include <iostream>

int main()
{
    int x{5};
    int y{4};

    std::cout << (x << 1) << "\n";

    std::cout << (y >> 1) << "\n";

    std::cout << ~x << "\n";
    // 00000000 00000101 = 5
    // 11111111 11111010 = ?
    
    return 0;
}