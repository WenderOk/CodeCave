#include <iostream>

template<typename T>
T Sum(int count, T first, ...)
{
    T sum{};
    T* p{&first};
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
    std::cout << Sum(2, 2.6, 3.5) << "\n";
    std::cout << Sum(2, 2.6, 3) << "\n";

    return 0;
}