#include <iostream>

int main()
{  
    int* x{ new int{ 25 } };
    std::cout << *x << '\n';

    int* y{ new int{ 52 } };
    std::cout << *y << '\n';

    int * other{ y };
    std::cout << *other << '\n';

    x = y;
    std::cout << *x << '\n';

    delete x;
    std::cout << *other << '\n';
    std::cout << *y << '\n';

    return 0;
}
