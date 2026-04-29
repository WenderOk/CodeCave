#include <iostream>

int Sum(int count, int first, ...)
{
    int sum{};
    int* p{&first};
    while(count--)
    {
        sum += *p;
        p++;
    }
    return sum;
}

int main()
{
    std::cout << Sum(2, 2, 3) << "\n";
    std::cout << Sum(4, 2, 3, 10, -5) << "\n";

    return 0;
}