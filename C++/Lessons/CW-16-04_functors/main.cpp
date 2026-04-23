#include <iostream>
#include "Counter.h"

int main()
{
    const int maxCnt{5};

    Counter cnt1;
    for(int i{}; i < maxCnt; i++)
        std::cout << cnt1() << " ";
    std::cout << "\n";

    cnt1.resetTo(10);
    
    for(int i{}; i < maxCnt; i++)
        std::cout << cnt1() << " ";
    std::cout << "\n";

    return 0;
}