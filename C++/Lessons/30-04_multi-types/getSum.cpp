#include <iostream>

double getSum(double x)
{
    return x;
}

// Args - packet of types
// args - packet of parameters
template<typename... Args>
double getSum(double x, Args... args)
{
    return x + getSum(args ...);
}

int main()
{
    std::cout << getSum(1,2,3,4,5) << '\n';
    std::cout << getSum(1.3,2.5,3.6,4.2,5.5) << '\n';
    std::cout << getSum(1,2,3.5,4.2,5.6) << '\n';
    return 0;
}