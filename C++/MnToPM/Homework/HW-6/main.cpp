#include <iostream>
#include "modules/lib.h"

int main()
{
    std::cout << "OutputNumbers: ";
    outputNumbers(10);
    std::cout << "Sum: " << sum(1,2) << '\n';
    std::cout << "Factorial: " << fact(3) << '\n';
    return 0;
}