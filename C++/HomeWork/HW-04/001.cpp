#include <iostream>

int main()
{
    int sum1{};
    int sum2{};

    int number{};

    std::cout << "Enter a six-digit number: ";
    std::cin >> number;

    if((number / 100000 < 1) | (number / 100000 > 9))
    {
        std::cout << "Wrong number!\n";
        return 1;
    }

    for(int i =0; i < 6; i++)
    {
        if(i>=3)
        {
            sum2 += number % 10;
            number /= 10;
        }
        else
        {
            sum1 += number % 10;
            number /= 10;
        }
    }

    if(sum1 == sum2)
    {
        std::cout << "This is a lucky number!\n" << sum1;
    }
    else
    {
        std::cout << "This is a regular number...\n" << sum2;
    }

    return 0;
}