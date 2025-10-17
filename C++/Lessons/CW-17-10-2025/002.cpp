#include <iostream>

int main()
{
    int menuItem{};
    int num1{};
    int num2{};

    enum menuItems {sum=1, diff, exit};
    
    do
    {
        std::cout << "Select operation\n"
                  << "1 - sum of A and B\n"
                  << "2 - difference of A and B\n"
                  << "3 - exit\n"
                  << "Your choice: ";
        std::cin >> menuItem;
        
        switch (menuItem)
        {
        case sum:
            std::cout << "Enter 2 numbers separating with space: ";
            std::cin >> num1 >> num2;
            std::cout << "Result: " << num1 + num2 << "\n";
            break;
        case diff:
            std::cout << "Enter 2 numbers separating with space: ";
            std::cin >> num1 >> num2;
            std::cout << "Result: " << num1 - num2 << "\n";
            break;
        case exit:
            std::cout << "Exiting...";
            break;
        default:
            std::cout << "Wrong menu item!\n";
            break;
        }
    } while (menuItem != 3);

    return 0;
}