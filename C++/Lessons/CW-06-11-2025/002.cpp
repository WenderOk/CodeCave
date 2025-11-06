#include <iostream>

void swap(int& x, int& y)
{
    int tmp{x};
    x = y;
    y = tmp;
}


int main()
{
    int a{1};
    int b{2};

    swap(a, b);

    std::cout << a << "\n" << b << "\n";

    return 0;
}