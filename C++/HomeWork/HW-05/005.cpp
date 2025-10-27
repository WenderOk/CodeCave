#include <iostream>

int main()
{
    int income{};
    int delayNum{};
    int code{};
    int userChoice{};
    int penalty{};

    double rowPrice{0.5};
    double temp{};
    
    std::cout << "1 - income and number of lateness-> number of code lines\n";
    std::cout << "2 - income and number of code lines -> number of lateness\n";
    std::cout << "3 - number of lateness and number of code lines ->income\n";
    std::cout << "Select menu item: ";
    std::cin >> userChoice;
    
    switch (userChoice)
    {
    case 1:
    {
        std::cout << "Enter target income: ";
        std::cin >> income;
        std::cout << "Enter delays number: ";
        std::cin >> delayNum;

        code = income / rowPrice;

        if (delayNum >= 3)
        {
            penalty = delayNum / 3 * 20;
        code = code + penalty / rowPrice;
        }
        std::cout <<"Number of code lines: "<< code << "\n";
    break;
    }
    case 2:
    {
        std::cout << "Enter target income: ";
        std::cin >> income;
        std::cout << "Enter number of code lines: ";
        std::cin >> code;

        temp = code * rowPrice;

        if (income >= temp)
            std::cout << "You are not allowed to be late!";
        
        else
        {
            delayNum = (temp - income) / 20 * 3;
            std::cout << "You are allowed to be late ";
            std::cout << delayNum << " or " << delayNum + 1;
            std::cout << " or " << delayNum + 2 << " times\n";
        }
    break;
    }
    case 3:
    {
        std::cout << "Enter number of code lines: ";
        std::cin >> code;
        std::cout << "Enter delays number: ";
        std::cin >> delayNum;

        temp = code * rowPrice;

        if (delayNum >= 3)
        {
            penalty = delayNum / 3 * 20;
            if (penalty >= temp)
                std::cout << "You’ll get nothing\n";
            
            else
            {
                income = temp - penalty;
                std::cout << "You’ll get " << income << " rub\n";
            }
        }
        else
        {
            income = temp;
            std::cout << "You’ll get " << income << " rub\n";
        }
    break;
    }
    default:
        std::cout << "Wrong input!";
    }
    return 0;
}