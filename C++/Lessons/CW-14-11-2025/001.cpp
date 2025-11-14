#include <iostream>

template <typename T>
T max(T a, T b, T c)
{
    T mx{a};
    if(mx < b) mx = b;
    if(mx < c) mx = c;
    return mx;
}

template <typename T1, typename T2, typename T3>
void print(T1 a, T2 b, T3 c)
{
    std::cout << a << " " << b << " " << c << "\n";
}

int main()
{
    print(1, 2, 3);
    print(3.2, 2.44, 3.123);
    print<double, int, long>(3.2, 2, 3.123L);
    return 0;
}


    
