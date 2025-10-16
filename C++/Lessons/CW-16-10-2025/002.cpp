#include <iostream>

int main()
{
    int num{1};

    while (num<=100)
    {
        std::cout << num << " ";
        num++;
    }

    std::cout << "\n";

    for(int i = 1; i <= 100; i++)
    {
        std::cout << i << " ";
    }

    return 0;
}