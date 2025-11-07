#include <iostream>

int sum(int a, int b, int c = 0)
{
    return a+b+c;
}



int main()
{
    std::cout << sum(1,2,3) << "\n";

    std::cout << sum(1,2) << "\n";

    return 0;
}