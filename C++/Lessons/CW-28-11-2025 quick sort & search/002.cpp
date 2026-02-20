#include <iostream>
#include <cstdarg>

int getMin(int numOfArgs...);

int sumInt(int numOfArgs...);
double sumDouble(int numOfArgs...);

template <typename T>
T sum(int numOfArgs...);

int main()
{
    std::cout << sum<double>(3,0.1,0.2,0.3) << "\n";
    std::cout << sum<int>(3,1,2,3) << "\n";

}

int getMin(int numOfArgs...)
{
    va_list va;
    va_start(va, numOfArgs);
    int minVal{va_arg(va, int)};

    for(int i{}; i < numOfArgs; i++)
    {
        int arg = va_arg(va, int);
        
        if(minVal > arg)
        {
            minVal = arg;
        }
    }
    va_end(va);

    return minVal;
}

template <typename T>
T sum(int numOfArgs...)
{
    va_list va;
    va_start(va, numOfArgs);
    T sum{};

    for(int i{}; i < numOfArgs; i++)
        sum += va_arg(va, T);
    va_end(va);

    return sum;
}

