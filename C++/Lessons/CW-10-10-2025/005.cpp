#include <iostream>

int main()
{
    double num1{};
    double num2{};
    double result{};
    char oper{};

    std::cout << "Enter expression (num1 operation num2): ";
    std::cin >> num1 >> oper >> num2;
    
    if (oper == '+')
    {
        result = num1 + num2;
    }
    else if (oper == '-')
    {
           result = num1 - num2;
    }
    else if (oper == '*')
    {
        result = num1 * num2;
    }
    else if (oper == '/')
    {
        if (!num2)
        {
            std::cout << "You can't divide by zero!";
        }
        else
        {
            result = num1 / num2;
        }
    }
    else
    {
        std::cout << "Invalid operator!";
    }
    
    std::cout << result << "\n";

    return 0;
}