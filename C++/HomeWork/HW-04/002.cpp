#include <iostream>
#include <cmath>

int main()
{
    int number{};
    int newNumber{};

    std::cout << "Enter a four-digit number: ";
    std::cin >> number;

    if((number / 1000 < 1) | (number / 1000 > 9))
    {
        std::cout << "Wrong number!\n";
        // написал 1 потому что это ведь код ошибки а неверный ввод это ошибка
        return 1;
    }

    for(int i = 1; i < 5; i++)
    {
        if(i % 2 == 0)
        {
            newNumber += number % 10 * pow(10, i-1);
            number /= 10;
        }
        else
        {
            newNumber += number % 10 * pow(10, i+1);
            number /= 10;
        }
    }
    // Знаю костыльное решение, но зато не пришлось разводить кучу переменных
    newNumber /= 10; 

    std::cout << "New number is: " << newNumber << "\n";

    return 0;
}