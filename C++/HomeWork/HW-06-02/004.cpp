#include <iostream>

int main()
{
    int number{};

    std::cout << "Enter a number: ";
    std::cin >> number;

    for(int i{number}; i > 0; i--)
    {
        if ((number % (i*i) == 0) && (number % (i*i*i) != 0))
        {
            std::cout << i << "\n";
        }
    }

    return 0;
}