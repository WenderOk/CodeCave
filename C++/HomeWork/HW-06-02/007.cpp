#include <iostream>

int main()
{
    int number1{};
    int number2{};
    int num{};

    std::cout << "Enter 2 numbers: ";
    std::cin >> number1 >> number2;

    if(number1 > number2)
        num = number1;
    else
        num = number2;

    for(int i{1}; i < num; i++)
    {
        if ((number1 % i == 0) && (number2 % i == 0))
            std::cout << i << "\n";
    }

    return 0;
}