#include <iostream>

int main()
{
    int number{};
    int digitSum{};

    std::cout << "Enter a number: ";
    std::cin >> number;

    while (number != 0)
    {
        digitSum += number % 10;
        number /= 10;
    } 

    if ((digitSum * digitSum * digitSum) == (number * number))
    {
        std::cout << "Yes" << "\n";
        std::cout << digitSum << "\n";
    }
    else
    {
        std::cout << "No" << "\n";
        std::cout << digitSum << "\n";
    }
    return 0;
}