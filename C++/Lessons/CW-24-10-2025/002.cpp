#include <iostream>

int main()
{
    for(int j{1}; j <= 9; j++)
    {
        for (int i{1}; i <= 9; i++)
        {
            std::cout << i*j << "\t";
        }
        std::cout << "\n";
    }

    return 0;
}