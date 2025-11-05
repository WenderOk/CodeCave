#include <iostream>

int main()
{
    int number{};

    std::cout << "Enter a number: ";
    std::cin >> number;

    for(int i{1}; i < number; i++)
    {
        if (number % i == 0)
            std::cout << i << "\n";
    }

    return 0;
}