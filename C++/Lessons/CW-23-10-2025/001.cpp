#include <iostream>
#include <iomanip>

int main ()
{
    std::cout << std::setprecision(20) << 0.1 + 0.2 << "\n";
    if (0.1 + 0.2 == 0.3)
        std::cout << "I can compare float!\n";
    else
        std::cout << "Something gone wrong\n";

    return 0;
}