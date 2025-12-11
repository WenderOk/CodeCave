#include <iostream>

int main()
{  
    int* x{ new int{ 25 } };
    std::cout << *x << '\n';

    delete x;
    x = nullptr;
    delete x;

    std::cout << "Prikl\n";

    return 0;
}
