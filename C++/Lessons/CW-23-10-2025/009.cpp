#include <iostream>

int main ()
{
    int max{};
    int min{};
    char answer{'y'};
    do
    {
        int num{};
        std::cout << "Enter number: ";
        std::cin >> num;

        if (num > max)
            max = num;

        if (num < min)
            min = num;
        
        std::cout << "Continue? (y,n): ";
        std::cin >> answer;

    }while(answer != 'n');

    std::cout << "maximum: " << max << "\n";
    std::cout << "minimum: " << min << "\n";

    return 0;
}