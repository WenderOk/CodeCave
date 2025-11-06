#include <iostream>

int sum(int a, int b)
{
    return a+b;
}
int mult(int a, int b)
{
    return a*b;
}
int divv(int a, int b)
{
    return a/b;
}
int diff(int a, int b)
{
    return a-b;
}

int main()
{
    int res{ sum(4,6) };
    std::cout << res << "\n";

    std::cout << sum(5.2, 6.8) << "\n";

    int x{12};
    int y{34};

    std::cout << sum(x + 5,y);
    return 0;
}