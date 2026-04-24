#include <iostream>

template<class T>
T max(T v1, T v2)
{ return v1 > v2 ? v1 : v2; }

template<>
const char* max<const char*>(const char* v1, const char* v2)
{ return (std::strcmp(v1, v2) ? v1 : v2); }

int main()
{
    int i1{10};
    int i2{20};
    std::cout << max(i1,i2) << '\n';

    double d1{10};
    double d2{20};
    std::cout << max(d1,d2) << '\n';

    const char* sc1("hi");
    const char* sc2("hi");
    std::cout << max(sc1,sc2) << '\n';
}