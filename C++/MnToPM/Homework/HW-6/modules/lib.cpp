#include <iostream>

int outputNumbers(int num)
{
    int i{};
    for(; i< num; i++)
        std::cout << i << " ";
    std::cout << "\n";

    return i;
}

int sum(int a, int b)
{
    return a+b;
}

int fact(int a)
{
    if(a < 0)
        return -1;
    else if((a == 1) || (a == 0))
        return 1;
    else
    {
        int res{1};
        for(int i{1}; i<=a; i++)
            res*=i;
        return res;
    }
}