#include <iostream>

int main()
{
    char symbol{'*'};
    int amount{1};
    int horizontal{1};

    std::cout << "Enter symbol: ";
    std::cin >> symbol;

    std::cout << "Amount of symbols that will be print: ";
    std::cin >> amount;

    std::cout << "Enter mode (1 - horizontal, 0 - vertical): ";
    std::cin >> horizontal;


    for (int i = 0; i < amount; i++)
    {
        if(horizontal)
        {  
           std::cout << symbol;
        }
        else
        {
            std::cout << symbol << "\n";
        }
    }    

    return 0;
}