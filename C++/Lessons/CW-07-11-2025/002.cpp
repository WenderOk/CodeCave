#include <iostream>


void second()
{
    std::cout << "Function second\n";
}

void first()
{
    std::cout << "Start function first\n";
    second();
    std::cout << "End function first\n";
}

int main()
{
    first();

    return 0;
}