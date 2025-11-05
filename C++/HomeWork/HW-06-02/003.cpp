#include <iostream>

int main()
{
    int origNumber{};
    int newNumber{};
    int digit{1};
    int grade{};

    std::cout << "Enter a number: ";
    std::cin >> origNumber;

    while (origNumber != 0)
    {
        digit = origNumber % 10;
        if ((digit != 3) && (digit != 6))
        {
            newNumber += digit * std::pow(10, grade);
            grade++;
        }
        origNumber /= 10;
    } 

    std::cout << newNumber << "\n";

    return 0;
}