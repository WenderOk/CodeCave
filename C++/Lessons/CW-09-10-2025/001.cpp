#include <iostream>

int main()
{
    int x{0};
    int y{10};
    // std::cout << ((x > 1) && (x < 10)) << "\n";
    // x=0;
    // std::cout << ((x > 1) && (x < 10)) << "\n";

if(x++)
{
    std::cout << "true \n";
}
else
{
    std::cout << "false \n";
}

    return 0;
}