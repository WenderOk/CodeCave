#include <iostream>

int main()
{
    int number{};
    int digitSum{};
    int tmp{};

    std::cout << "Enter a number: ";
    std::cin >> number;

    tmp = number;

    while (tmp != 0)
    {
        digitSum += tmp % 10;
        tmp /= 10;
    } 

    std::cout << "Cude of digits: " << digitSum * digitSum * digitSum << "\n";
    std::cout << "Square of number: " << number * number << "\n";
    std::cout << "Condition is true?\n";
    if ((digitSum * digitSum * digitSum) == (number * number))
        std::cout << "Yes" << "\n";
    else
        std::cout << "No" << "\n";
    
    return 0;
}