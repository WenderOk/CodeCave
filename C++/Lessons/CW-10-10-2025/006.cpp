#include <iostream>

int main()
{
    double num1{};
    double num2{};
    double result{};
    char oper{};

    std::cout << "Enter expression (num1 operation num2): ";
    std::cin >> num1 >> oper >> num2;

    switch (oper)
    {
    case '+':
        result = num1 + num2;
        break;
    case '-':
        result = num1 - num2;
        break;
    case '*':
        result = num1 * num2;
        break;
    case '/':
        if (!num2)
        {
            std::cout << "You can't divide by zero!";
            return 0;
        }
        else
        {
            result = num1 / num2;
        }
        break;
    default:
        std::cout << "Invalid operator!";    
        return 0;
        break;
    }
    
    std::cout << result << "\n";

    return 0;
}


