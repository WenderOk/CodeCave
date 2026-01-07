#include <iostream>

int binToDec(int number);
int pow(int number, int power);

int main()
{
    int number{};
    std::cout << "Enter a binary number: ";
    std::cin >> number;
    std::cout << "Decimal number: " << binToDec(number) << "\n";
 
    return 0;
}

int binToDec(int number)
{
    int result{};
    int power{};
    do
    {
        if(number % 10 == 1) result += pow(2, power);
        number = number / 10;
        power++;
    }
    while(number != 0);
    return result;
}

int pow(int number, int power)
{
    int result{1};
    for(int i{}; i < power; i++)
        result *= number;
    return result;
}